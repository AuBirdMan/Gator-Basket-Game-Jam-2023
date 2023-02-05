using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float time = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        timeText.text = ((int)time).ToString();
        PlayerPrefs.SetInt("FinalTime", (int)time);
    }
}
