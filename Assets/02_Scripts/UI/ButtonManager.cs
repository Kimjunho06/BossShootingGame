using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    
    private void Start()
    {
        
    }






    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage_1");
    }
}
