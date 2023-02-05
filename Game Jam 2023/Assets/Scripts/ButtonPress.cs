using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject button;
    private float _ButtonRisedelay;
    public float ButtonRisedelay;
    private bool onButton;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Tall" || col.gameObject.tag == "Short"){
            button.SetActive(false);
            _ButtonRisedelay = ButtonRisedelay;
            onButton = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        onButton = false;
        
    }
    void Update(){
        if(onButton == false){
            _ButtonRisedelay -= Time.deltaTime;
            if(_ButtonRisedelay <= 0f){
                button.SetActive(true);
            }
        }
    }

}
