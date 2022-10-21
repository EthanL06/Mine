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

    void Mine() {
        GameObject floatingMoney = Instantiate(floatingMoneyPrefab, new Vector3(-186.1f, 153f, 0), Quaternion.identity);
        floatingMoney.GetComponentInChildren<TextMeshProUGUI>().SetText("+$10");
        floatingMoney.transform.SetParent(canvas.transform, false);
        Destroy(floatingMoney, 0.7f);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Mine();
        }
    }


    
}
