using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    
    private TextMeshProUGUI text;
    [SerializeField] private Ore ore;
    private Progress progress;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        progress = new Progress(ore.initialUpgrade);
        if (ore.type == OreType.Stone) {
            text.SetText(progress.GetUpgradeText());
            return;
        };
        text.SetText("UNLOCK MINE (" + MoneyManager.moneyConversion(ore.costToUnlock) + ")");
    }

    public void Upgrade() {
        double money = MoneyManager.GetMoney();

        if (!ore.isUnlocked && money >= ore.costToUnlock) {
            MoneyManager.SubtractMoney(ore.costToUnlock);
            ore.isUnlocked = true;
            text.SetText(progress.GetUpgradeText());
            ore.Unlock();
        } else if (money >= progress.NextUpgradeCost()) {
            MoneyManager.SubtractMoney(progress.NextUpgradeCost());

            progress.AddLevel();
            text.SetText(progress.GetUpgradeText());

            if (progress.GetLevel() == 4 || progress.GetLevel() == 8) {
                ore.SetWaitTime(ore.GetWaitTime() - (ore.GetWaitTime() *  progress.GetReducedTime()));
            } else {
                ore.SetMultiplier(ore.multiplier + progress.GetMultiplier());
            }

            if (progress.GetLevel() == Progress.MAX_LEVEL) {
                Destroy(this);
            }
            
        }
    }
}

internal class Progress {
    
    public const int MAX_LEVEL = 11;
    private int level;
    private int numOfMiners;
    private double multiplier;
    private float reducedTime;
    private double initialUpgrade;

    public Progress(double initialUpgrade) {
        level = 0;
        numOfMiners = 0;
        multiplier = 1;
        reducedTime = 0;
        this.initialUpgrade = initialUpgrade;
    }

    public void AddLevel() {
        if (level > MAX_LEVEL) return;

        level++;
        Upgrade();
    }

    private void Upgrade() {
        switch (level) {
            case 4:
                reducedTime = 0.5f;
                break;
            case 8:
                reducedTime = 1f;
                break;
            default:
                numOfMiners++;
                multiplier = (0.25 * Mathf.Pow(2, numOfMiners));
                break;
        }
    }

    public double NextUpgradeCost() {
        return initialUpgrade * Mathf.Pow(2f, level);
    }

    public string GetUpgradeText() {
        Debug.Log("Level: " + level);
        if (level == MAX_LEVEL) return "MAXED UPGRADES";

        switch (level) {
            case 3:
                return "REDUCE WAIT TIME BY 50% (" + MoneyManager.moneyConversion(NextUpgradeCost()) + ")";
            case 7:
                return "REDUCE WAIT TIME BY 100% (" + MoneyManager.moneyConversion(NextUpgradeCost()) + ")";
            default:
                return "+" + (0.25 * Mathf.Pow(2, numOfMiners + 1)) + "x MULT. (" + MoneyManager.moneyConversion(NextUpgradeCost()) + ")";
        }
    }

    public double GetMultiplier() {
        return multiplier;
    }

    public float GetReducedTime() {
        return reducedTime;
    }

    public int GetLevel() {
        return level;
    }
}
