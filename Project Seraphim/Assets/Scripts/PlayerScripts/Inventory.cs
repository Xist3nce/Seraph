using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SeraphLibrary
{
    public static Inventory instance;
    public ItemSlot[] itemSlotList;
    //public GameObject[] olditemList;
    public GameObject selectedObject;
    



    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    void PickUpItem(GameObject itemGO)
    {

    }

    void PickUpWeapon(GameObject weaponGO)
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


    //public int FindEmptySlot()
    //{
    //    int loopCounter = 0;
    //    while (loopCounter <= itemList.Length)
    //    {
    //        if (itemList[loopCounter] == null)
    //        {
    //            return loopCounter;
    //        }
    //        else
    //        {
    //            loopCounter++;

    //        }
    //    }
    //    return loopCounter;
    //}



    public void RemoveItem(int itemNumber)
    {

    }
}
