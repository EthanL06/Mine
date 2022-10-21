using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{

    public float timeToEnd;
    public float time = 0;
    public bool isRunning;
    public OreType type;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image fillImage;
    private Action callback;

    public void Initiate() {
        if (isRunning) return;
        StartCoroutine(StartTimer(callback));
    }

    private IEnumerator StartTimer(Action end) {
        isRunning = true;
        fillImage.color = Color.white;

        while (time < timeToEnd) {
            time += Time.deltaTime;
            slider.value = time / timeToEnd;
            yield return null;
        }

        isRunning = false;
        fillImage.color = new Color(111f/255f, 255f/255f, 102f/255f);
        time = 0;

        end();
    }

    public void SetCallback(Action callback) {
        this.callback = callback;
    }
}
