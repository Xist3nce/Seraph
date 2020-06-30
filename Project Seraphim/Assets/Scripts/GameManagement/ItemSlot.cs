using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public GameObject slottedItemGO;
    public SpriteRenderer slotSpriteRenderer;




    public void AddItem(GameObject item)
    {
        //item.GetComponent<Item>().SpriteRenderer()
        slottedItemGO = item;
        item.transform.SetParent(transform);
        item.transform.localPosition = new Vector3(0, 0, 0);
        slotSpriteRenderer = item.GetComponent<Item>().SpriteRenderer();

    }

    public bool isOccupied()
    {
        if (slottedItemGO)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearSlot()
    {
        slottedItemGO = null;
    }
}
