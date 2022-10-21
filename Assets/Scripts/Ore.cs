using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OreType {
    Stone, Coal, Iron, Gold, Gem
}

public class Ore : MonoBehaviour
{
    public OreType type;
    public float moneyValue;
    public float costToUnlock;

    public SliderTimer sliderTimer;

    private void Start() {
        sliderTimer = this.gameObject.GetComponent<SliderTimer>();
        sliderTimer.SetCallback(AddMoney);
    }

    public void Mine() {
        sliderTimer.Initiate();
    }

    public void AddMoney() {
        OreManager.AddMoney(moneyValue);
    }

    
}
