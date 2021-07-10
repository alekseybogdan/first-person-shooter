using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockItem : MonoBehaviour
{
    public int price;
    private int index;

    public void SetIndexAndTryBuyingItem()
    {
        string buttonName = gameObject.name;
        var stockToScan = gameObject.GetComponentInParent<StockHolder>().stock;

        int i;
        for(i = 0; i < stockToScan.Length; i++)
        {
            if(string.Equals(buttonName, stockToScan[i].name))
            {
                index = i;
                break;
            }
        }
        //-------------
        gameObject.GetComponentInParent<StockHolder>().TryBuyingItem(index);
    }

    public void UnlockItem()
    {
        foreach(Transform child in transform)
        {
            if(string.Equals(child.gameObject.name, "Locked"))
            {
                child.gameObject.SetActive(false);
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
