using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SeraphLibrary
{
    public static Inventory instance;
    public GameObject[] itemList;
    public GameObject[] olditemList;
    public GameObject selectedObject;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    public void AddItem(GameObject item, int arrayLocation)
    {
        //In testing 
        //olditemList = itemList; //Old item list is a fallback to refer to the old list once I figure out a swapping mechanism.
        //int newListSize = (olditemList.Length + 1);
        //itemList = new GameObject[newListSize];
        //int loopCounter = 0;
        //while (loopCounter < newListSize)
        //{
        //    itemList[loopCounter] = olditemList[loopCounter];
        //    loopCounter++;
        //}
        //if (loopCounter == newListSize)
        //{
        //    itemList[loopCounter] = item;
        //}
    }


    public int FindEmptySlot()
    {
        int loopCounter = 0;
        while (loopCounter <= itemList.Length)
        {
            if (itemList[loopCounter] == null)
            {
                return loopCounter;
            }
            else
            {
                loopCounter++;
                
            }
        }
        return loopCounter;
    }



    public void RemoveItem(int itemNumber)
    {

    }
}
