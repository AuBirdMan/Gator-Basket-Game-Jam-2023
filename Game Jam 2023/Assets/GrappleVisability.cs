using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleVisability : MonoBehaviour
{
    private SpriteRenderer renderer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.transform.GetChild(0).gameObject.activeInHierarchy){
            renderer.enabled = false;
        }
        else{
            renderer.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
