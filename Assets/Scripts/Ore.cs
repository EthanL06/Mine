using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum OreType {
    Stone, Coal, Iron, Gold, Gem
}



public class Ore : MonoBehaviour
{
    public OreType type;
    public double moneyValue;
    public double multiplier = 1;
    public bool isUnlocked;
    public double costToUnlock;
    public double initialUpgrade;

    public SliderTimer sliderTimer;
    public FloatingMoney floatMoneyManager;
    public Vector2 floatingMoneyPosition;
    public TextMeshProUGUI multiplierText;

    private GameObject slider;
    private Button button;

    private void Start() {
        isUnlocked = (type == OreType.Stone) ? true : false;
        multiplierText = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponentInChildren<Slider>().gameObject;
        button = GetComponentInChildren<Button>();

        if (!isUnlocked) {
            // Get component with name of 
            multiplierText.gameObject.SetActive(false);
            slider.SetActive(false);
            button.interactable = false;
        } 

        sliderTimer = this.gameObject.GetComponent<SliderTimer>();
        sliderTimer.SetCallback(AddMoney);
    }

    

    // Call slider timer initiate every second 

    public void Mine() {
        sliderTimer.Initiate();
    }

    public void AddMoney() {
        MoneyManager.AddMoney(moneyValue * multiplier);
        floatMoneyManager.Show(floatingMoneyPosition, moneyValue * multiplier);
    }

    public void SetMultiplier(double multiplier) {
        this.multiplier = multiplier;
        multiplierText.SetText(multiplier + "x mult.");
    }

    public void SetWaitTime(float waitTime) {
        sliderTimer.waitTime = waitTime;
        sliderTimer.SetValue(1);

        if (waitTime == 0) {
            InvokeRepeating("AddMoney", 1f, 1f);
        }
    }

    public float GetWaitTime() {
        return sliderTimer.waitTime;
    }

    public void Unlock() {
        isUnlocked = true;
        slider.SetActive(true);
        multiplierText.gameObject.SetActive(true);
        button.interactable = true;

        // Get Canvas Group component and set alpha to 1
        CanvasGroup canvasGroup = this.gameObject.GetComponentInChildren<CanvasGroup>();
        canvasGroup.alpha = 1;


        // Get component with name of Lock inside of this game object and set it to inactive
        GameObject lockObject = this.gameObject.transform.Find("Lock").gameObject;
        lockObject.SetActive(false);

    }

}






