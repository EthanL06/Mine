using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public CanvasGroup titleScreen;
    public CanvasGroup mineScreen;
    public CanvasGroup shopScreen;
    public CanvasGroup constantScreen;

    private void Awake() {
        ShowTitleScreen();
    }

    public void ShowTitleScreen() {
        titleScreen.alpha = 1;
        titleScreen.interactable = true;
        titleScreen.blocksRaycasts = true;
    }

    public void HideTitleScreen()
    {
        titleScreen.alpha = 0;
        titleScreen.interactable = false;
        titleScreen.blocksRaycasts = false;
        ToggleMineScreen();
        ToggleConstantScreen();
    }

    public void ShowMineScreen() {
        HideShopScreen();
        mineScreen.alpha = 1;
        mineScreen.interactable = true;
        mineScreen.blocksRaycasts = true;
    }

    void HideMineScreen() {
        mineScreen.alpha = 0;
        mineScreen.interactable = false;
        mineScreen.blocksRaycasts = false;
    }

    public void ToggleMineScreen()
    {
        if (mineScreen.alpha == 0)
        {
            ShowMineScreen();
        }
        else
        {
            HideMineScreen();
        }
    }

    public void ShowShopScreen() {
        HideMineScreen();
        shopScreen.alpha = 1;
        shopScreen.interactable = true;
        shopScreen.blocksRaycasts = true;
    }

    void HideShopScreen() {
        shopScreen.alpha = 0;
        shopScreen.interactable = false;
        shopScreen.blocksRaycasts = false;
    }


    public void ToggleShopScreen()
    {
        if (shopScreen.alpha == 0)
        {
            ShowShopScreen();
        }
        else
        {
            HideShopScreen();
        }
    }

    public void ToggleConstantScreen()
    {
        if (constantScreen.alpha == 0)
        {
            constantScreen.alpha = 1;
            constantScreen.interactable = true;
            constantScreen.blocksRaycasts = true;
        }
        else
        {
            constantScreen.alpha = 0;
            constantScreen.interactable = false;
            constantScreen.blocksRaycasts = false;
        }
    }
}
