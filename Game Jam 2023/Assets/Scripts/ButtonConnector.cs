using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConnector : MonoBehaviour
{
    public GameObject button;
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = !button.transform.GetChild(0).gameObject.activeInHierarchy;
    }

    // Update is called once per frame
    void Update(){
        isPressed = !button.transform.GetChild(0).gameObject.activeInHierarchy;
        if(isPressed){
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else{
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
}
