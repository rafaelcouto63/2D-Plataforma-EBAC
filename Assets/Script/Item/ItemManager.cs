using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public int coins;
    public TextMeshProUGUI coinText;

    private void Awake() 
    {
        if(instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UpdateCoinText();
    }

    public void AddCoin(int amount = 1)
    {
        coins += amount;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "X " + coins.ToString(); 
    }
}
