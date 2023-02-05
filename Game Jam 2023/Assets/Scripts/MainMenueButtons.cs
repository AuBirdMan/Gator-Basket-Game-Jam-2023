using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenueButtons : MonoBehaviour
{
    private GameObject[] panels;
    void Start()
    {
        panels = FindObjectsOfType<GameObject>();
    }

    public void StartGame(){
        SceneManager.LoadScene("Back2Basics");
    }
    public void Option(){
        foreach (var panel in panels)
        {
            if(panel.name == "Options"){
                panel.SetActive(true);
            }
        }
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Credits(){
        foreach (var panel in panels)
        {
            if(panel.name == "Credits"){
                panel.SetActive(true);
            }
        }
    }

    public void Back(){
        foreach (var panel in panels)
        {
            if(panel.name == "Options" || panel.name == "Credits"){
                panel.SetActive(true);
            }
        }
    }
}
