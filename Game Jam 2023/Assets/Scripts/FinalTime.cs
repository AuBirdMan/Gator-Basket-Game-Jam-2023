using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTime : MonoBehaviour
{

    // Start is called before the first frame update

    public int LoadNumber()
    {
        return PlayerPrefs.GetInt("FinalTime");
    }
}
