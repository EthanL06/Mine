using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FloatingMoney : MonoBehaviour
{
    [SerializeField] private GameObject floatingMoneyPrefab;
    [SerializeField] private GameObject floatingMoneyParent;
    // private Canvas canvas;

    private void Start() {
        // canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void Show(Vector2 position, double money) {
        GameObject floatingMoney = Instantiate(floatingMoneyPrefab, position, Quaternion.identity);
        floatingMoney.GetComponentInChildren<TextMeshProUGUI>().SetText(MoneyManager.moneyConversion(money));
        floatingMoney.transform.SetParent(floatingMoneyParent.transform, false);
        Destroy(floatingMoney, 0.6f);
    }

}
