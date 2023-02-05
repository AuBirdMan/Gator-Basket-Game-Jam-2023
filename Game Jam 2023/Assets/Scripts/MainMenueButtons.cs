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
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(4).gameObject.SetActive(true);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Credits(){
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Back(){
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
    }
}
