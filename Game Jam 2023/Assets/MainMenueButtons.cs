using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenueButtons : MonoBehaviour
{

    public void StartGame(){
        SceneManager.LoadScene("Back2Basics");
    }
    public void Option(){

    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Credits(){
        GameObject credits = GameObject.Find("Credits");
        credits.SetActive(true);
    }
}
