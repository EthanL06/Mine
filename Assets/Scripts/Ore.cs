using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum OreType {
    Stone, Coal, Iron, Gold, Gem, Special
}



public class Ore : MonoBehaviour
{
    [SerializeField]
    private static int totalFullyUpgraded = 0;
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
        double money = moneyValue * multiplier;

        if (type == OreType.Special) {
            // Random number between 1 billion and 1 trillion
            money = Random.Range(1000000000, 1000000000000);
        }

        MoneyManager.AddMoney(money);
        floatMoneyManager.Show(floatingMoneyPosition, money);
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

        if (type == OreType.Special) {
            sliderTimer.waitTime = 0;
            InvokeRepeating("AddMoney", 1f, 0.3f);
        }

    }

    public static void AddFullyUpgrade() {
        Debug.Log("Total fully upgraded: " + totalFullyUpgraded);
        totalFullyUpgraded++;

        if (totalFullyUpgraded == 5) {
            // Unlock special mine
            GameObject specialMine = GameObject.Find("Special Mine");
            specialMine.GetComponent<Ore>().Unlock();
            specialMine.GetComponentInChildren<RawImage>().texture = Resources.Load<Texture>("Special");
            // Get Gameobject with the name of ? in specialMine and set it to inactive
            GameObject questionMark = specialMine.transform.Find("?").gameObject;
            questionMark.SetActive(false);

        }
    }

}






