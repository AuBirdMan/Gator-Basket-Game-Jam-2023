using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenueButtons : MonoBehaviour
{
    private Panel credits[];
    void Start()
    {
        Panel credits[] = FindObjectsOfType<Panel>;
    }

    public void StartGame(){
        SceneManager.LoadScene("Back2Basics");
    }
    public void Option(){

    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Credits(){
        credits.enabled=true;
    }
}
