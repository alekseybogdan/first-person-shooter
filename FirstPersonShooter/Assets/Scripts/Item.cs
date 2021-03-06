using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.gameObject.GetComponent<Inventory>();
            inv.inventory.Add(gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
