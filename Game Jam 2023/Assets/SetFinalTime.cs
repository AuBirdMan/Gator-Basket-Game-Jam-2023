using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetFinalTime : MonoBehaviour
{
    // Start is called before the first frame update
    private int finalTime;
    void Awake()
    {
        finalTime = PlayerPrefs.GetInt("FinalTime");
        gameObject.GetComponent<TextMeshProUGUI>().text = finalTime.ToString();
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
