using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockHolder : MonoBehaviour
{
    public StockItem[] stock;

    private int playerBalance;

    public void SetBalance(int balance)
    {
        playerBalance = balance;
    }

    public int GetBalance()
    {
        return playerBalance;
    }

    public void TryBuyingItem(int itemIndex)
    {
        if(stock[itemIndex].price <= playerBalance)
        {
            playerBalance -= stock[itemIndex].price;
            stock[itemIndex].UnlockItem();
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<MoneyBalance>().balanceText.text = string.Format("${0}", playerBalance);
        }
        else
        {
            Debug.Log("Insufficient money!");
        }
    }
}
