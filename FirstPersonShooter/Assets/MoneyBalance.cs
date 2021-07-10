using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBalance : MonoBehaviour
{
    private int balance;
    public Text balanceText;

    public StockHolder stockHolder;
    // Start is called before the first frame update
    void Start()
    {
        balance = stockHolder.GetBalance();
        balanceText.text = string.Format("${0}", balance);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            balance += other.GetComponent<Coin>().moneyAmount;
            stockHolder.SetBalance(balance);
            balanceText.text = string.Format("${0}", balance);
        }
    }
}
