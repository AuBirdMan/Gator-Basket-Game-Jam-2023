using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    [SerializeField] private AudioSource idle;
    [SerializeField] private AudioSource warp;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Tall" || col.gameObject.tag == "Short"){
            idle.volume = 0;
            warp.Play();
            SceneManager.LoadScene(2);
        }
    }
}
