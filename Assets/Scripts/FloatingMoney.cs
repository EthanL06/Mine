using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FloatingMoney : MonoBehaviour
{
    [SerializeField] private GameObject floatingMoneyPrefab;
    private Canvas canvas;

    private void Start() {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void Show(Vector2 position, float money) {
        GameObject floatingMoney = Instantiate(floatingMoneyPrefab, position, Quaternion.identity);
        floatingMoney.GetComponentInChildren<TextMeshProUGUI>().SetText("+$" + money);
        floatingMoney.transform.SetParent(canvas.transform, false);
        Destroy(floatingMoney, 0.7f);
    }

}
