using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{

    StartMenu _startMenu;
    
    
    private void Awake()
    {   
        _startMenu = GameObject.Find("ModeSelectBgr").GetComponent<StartMenu>();
    }

    public void SelectModeO()
    {
        _startMenu.SelectModeOpen();
    }
    public void SelectModeC()
    {
        _startMenu.SelectModeClose();
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
