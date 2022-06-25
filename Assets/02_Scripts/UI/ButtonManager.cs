using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    HelpButton _helpButton;
    
    

    public void HelpO()
    {
        _helpButton = GameObject.Find("HelpBgr").GetComponent<HelpButton>();
        _helpButton.OpenHelp();
    }
    public void HelpC()
    {
        _helpButton = GameObject.Find("HelpBgr").GetComponent<HelpButton>();
        _helpButton.CloseHelp();
    }



    #region ¾À ÀüÈ¯
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void PlayerMode()
    {
        SceneManager.LoadScene("PlayerMode_1");
    }
    
    public void BossMode()
    {
        SceneManager.LoadScene("BossMode_1");
    }

    public void MultiplayMode()
    {
        SceneManager.LoadScene("MultiplayMode_1");
    }
    #endregion
}
