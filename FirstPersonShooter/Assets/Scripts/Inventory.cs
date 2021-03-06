using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> inventory;
    public bool HasItem(string requiredItemName, bool takeItem)
    {
        var hasItem = false;
        if (inventory.Contains(requiredItemName))
        {
            if (takeItem == true) inventory.Remove(requiredItemName);
            hasItem = true;
        }
        return hasItem;
    }
}
