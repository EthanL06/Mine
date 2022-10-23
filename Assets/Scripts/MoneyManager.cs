using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyManager : MonoBehaviour
{
    private static double totalMoney = 0;
    [SerializeField] private TextMeshProUGUI moneyText;

    public static double AddMoney(double money) {   
        totalMoney += money;
        return totalMoney;
    }

    public static double SubtractMoney(double money) {
        totalMoney -= money;
        return totalMoney;
    }

    private void Update() {
        // Add commas to the money text with trailing zeros
        moneyText.text = moneyConversion();
    }

    public static string moneyConversion(double money) {
         if (money < 1000) {
            return "$" + money.ToString("N2");
        }

        // If totalMoney is greater than quintillion, set it in terms of exponents
        if (money > 1000000000000000000) {
            return "$" + (money / 1000000000000000000).ToString("N2") + "Q";
        }

        // If totalMoney is greater than quadrillion, set it in terms of exponents
        if (money > 1000000000000000) {
            return "$" + (money / 1000000000000000).ToString("N2") + "Q";
        }

        // If totalMoney is greater than trillion, set it in terms of exponents
        if (money > 1000000000000) {
            return "$" + (money / 1000000000000).ToString("N2") + "T";
        }

        // If totalMoney is in the billions, set in billions
        if (money >= 1000000000) {
            return "$" + (money / 1000000000).ToString("N2") + "B";
        }

        // If totalMoney is in the millions, set in millions
        if (money >= 1000000) {
            return "$" + (money / 1000000).ToString("N2") + "M";
        }

        // If totalMoney is in the thousands, set in thousands
        if (money >= 1000) {
            return "$" + (money / 1000).ToString("N2") + "K";
        }
        
        return "$" + money.ToString("N2");
    }

    private string moneyConversion() {
        return moneyConversion(totalMoney);
    }

    public static double GetMoney() {
        return totalMoney;
    }
}
