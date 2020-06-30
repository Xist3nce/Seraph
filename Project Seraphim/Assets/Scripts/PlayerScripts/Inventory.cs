using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SeraphLibrary
{
    public static Inventory instance;
    public ItemSlot[] itemSlotList;
    //public GameObject[] olditemList;
    public GameObject selectedObject;
    public GameObject aimer;
    [Space]
    public GameObject InventoryUI;
    public GameObject SlotHolder;
    [Space]
    public GameObject equippedWeapon;
    



    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        PopulateItemSlots();
        
    }


    void PickUp(Item objectitem)
    {
        if (objectitem.GetItemType() == ItemType.weapon)
        {
            PickUpWeapon(objectitem);
        }
        if (objectitem.GetItemType() == ItemType.relic)
        {
            PickUpItem(objectitem);
        }
        if (objectitem.GetItemType() == ItemType.consumable)
        {
            PickUpItem(objectitem);
        }
    }
    void PickUpItem(Item itemGO)
    {

    }

    void PickUpWeapon(Item weapon)
    {
        if (equippedWeapon == null)
        {
            EquipWeapon(weapon.gameObject);
        }
        else
        {
            AddItemToInventory(weapon.gameObject);
        }
    }



    //The actual Equip weapon function
    public void EquipWeapon(GameObject weapon)
    {
        if (equippedWeapon != null)
        {
            AddItemToInventory(equippedWeapon);
            equippedWeapon = weapon;
            weapon.transform.SetParent(aimer.transform);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
        }

        if (equippedWeapon == null)
        {
            equippedWeapon = weapon;
            weapon.transform.localPosition = new Vector3(0, 0, 0);

        }
    }


    public void AddItemToInventory(GameObject itemToAdd)
    {

    }
    //public void AddItem(GameObject item, int arrayLocation)
    //{
    //    //Deprecated but possibly useful later.
    //    //olditemList = itemList; //Old item list is a fallback to refer to the old list once I figure out a swapping mechanism.
    //    //int newListSize = (olditemList.Length + 1);
    //    //itemList = new GameObject[newListSize];
    //    //int loopCounter = 0;
    //    //while (loopCounter < newListSize)
    //    //{
    //    //    itemList[loopCounter] = olditemList[loopCounter];
    //    //    loopCounter++;
    //    //}
    //    //if (loopCounter == newListSize)
    //    //{
    //    //    itemList[loopCounter] = item;
    //    //}
    //}


    public int FindEmptySlot()
    {
        int loopCounter = 0;
        while (loopCounter < itemSlotList.Length)
        {
            if (itemSlotList[loopCounter].isOccupied() == false)
            {
                Debug.Log("Empty Slot found at " + loopCounter);
                return loopCounter;
            }
            else
            {
                loopCounter++;

            }
        }
        Debug.Log("No Empty slot found");
        return -1; //Failstate
    }

    public void DebugEmptySlotTest()
    {
        Debug.Log("Empty slot is " + FindEmptySlot());

    }

    public void RemoveItem(int itemNumber)
    {
        itemSlotList[itemNumber].ClearSlot();
    }

    public void PopulateItemSlots()
    {
        if (SlotHolder) //Safety Nullcheck
        {
            int LoopCounter = 0;
            int childCount = SlotHolder.transform.childCount;
            itemSlotList = new ItemSlot[childCount];
            while (LoopCounter < childCount)
            {
                itemSlotList[LoopCounter] = SlotHolder.transform.GetChild(LoopCounter).transform.GetComponent<ItemSlot>(); // This is ugly as hell, but boils down to getting the correct child's itemslot script. I am gravely sorry.
                //This was to test population, worked like a charm.//Debug.Log("ItemSlotlist " + LoopCounter + " populated");
                LoopCounter++;
            }
        }
    }
}
