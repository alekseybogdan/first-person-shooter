using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsShop : MonoBehaviour
{
    public GameObject[] bulletsStock;
    public GameObject shopPanel;

    public PauseMenu pauseMenu;
    private int balance;
    // Start is called before the first frame update
    void Start()
    {
        shopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!pauseMenu.isGamePaused && Input.GetKeyDown(KeyCode.Tab))
        {
            shopPanel.SetActive(true);
            pauseMenu.PauseGame(true);
        }
        else if(pauseMenu.isGamePaused && !pauseMenu.pauseMenuUI.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            shopPanel.SetActive(false);
            pauseMenu.PauseGame(false);
        }
    }
}
