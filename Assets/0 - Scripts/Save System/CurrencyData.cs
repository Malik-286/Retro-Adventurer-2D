using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CurrencyData
{
    public int coins;


    public CurrencyData(CurrencyManager currencyManager)
    {
        coins = currencyManager.GetCurrentCoins();

    }




}
