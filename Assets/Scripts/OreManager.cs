using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OreManager : MonoBehaviour
{
    public Ore stoneOre;
    public Ore coalOre;
    public Ore ironOre;
    public Ore goldOre;
    public Ore gemOre;


    private static double totalMoney = 0;
    [SerializeField] private TextMeshProUGUI moneyText;

    public static double AddMoney(float money) {   
        totalMoney += money;
        return totalMoney;
    }

    public static double RemoveMoney(float money) {
        totalMoney -= money;
        return totalMoney;
    }

    private void Update() {
        // Add commas to the money text with trailing zeros
        moneyText.text = moneyConversion();
    }

    private string moneyConversion() {
        if (totalMoney < 1000) {
            return "$" + totalMoney.ToString("N2");
        }

        // If totalMoney is greater than quintillion, set it in terms of exponents
        if (totalMoney > 1000000000000000000) {
            return "$" + (totalMoney / 1000000000000000000).ToString("N2") + "Q";
        }

        // If totalMoney is greater than quadrillion, set it in terms of exponents
        if (totalMoney > 1000000000000000) {
            return "$" + (totalMoney / 1000000000000000).ToString("N2") + "Q";
        }

        // If totalMoney is greater than trillion, set it in terms of exponents
        if (totalMoney > 1000000000000) {
            return "$" + (totalMoney / 1000000000000).ToString("N2") + "T";
        }

        // If totalMoney is in the billions, set in billions
        if (totalMoney >= 1000000000) {
            return "$" + (totalMoney / 1000000000).ToString("N2") + "B";
        }

        // If totalMoney is in the millions, set in millions
        if (totalMoney >= 1000000) {
            return "$" + (totalMoney / 1000000).ToString("N2") + "M";
        }

        // If totalMoney is in the thousands, set in thousands
        if (totalMoney >= 1000) {
            return "$" + (totalMoney / 1000).ToString("N2") + "K";
        }
        
        return "$" + totalMoney.ToString("N2");
    }
}
