using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenueButtons : MonoBehaviour
{
    public GameObject canvas1, canvas2;
    
    private GameObject[] panels;

    public void StartGame(){
        SceneManager.LoadScene("Back2Basics");
    }
    public void Options(){
        canvas2.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Credits(){
        canvas1.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Back(){
        canvas1.transform.GetChild(0).gameObject.SetActive(false);
        canvas2.transform.GetChild(0).gameObject.SetActive(false);
    }
}
