using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public CanvasGroup titleScreen;
    public CanvasGroup mineScreen;
    public CanvasGroup shopScreen;

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
    }

    public void ToggleMineScreen()
    {
        if (mineScreen.alpha == 0)
        {
            mineScreen.alpha = 1;
            mineScreen.interactable = true;
            mineScreen.blocksRaycasts = true;
        }
        else
        {
            mineScreen.alpha = 0;
            mineScreen.interactable = false;
            mineScreen.blocksRaycasts = false;
        }
    }

    public void ToggleShopScreen()
    {
        if (shopScreen.alpha == 0)
        {
            shopScreen.alpha = 1;
            shopScreen.interactable = true;
            shopScreen.blocksRaycasts = true;
        }
        else
        {
            shopScreen.alpha = 0;
            shopScreen.interactable = false;
            shopScreen.blocksRaycasts = false;
        }
    }
}
