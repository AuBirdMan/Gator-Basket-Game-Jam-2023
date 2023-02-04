using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imaginaryfriend : MonoBehaviour
{

    private Rigidbody2D wisp;
    private Vector2 player_pos;
    public GameObject player_go;

    // Start is called before the first frame update
    void Start(){

     wisp = GetComponent<Rigidbody2D>();
     wisp.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update(){

        if (player_go.transform.GetChild(0).gameObject.activeSelf)
        {
            wisp.gameObject.SetActive(true);
        }
        else 
        { 
            wisp.gameObject.SetActive(false);
        }

        player_pos = player_go.transform.position;
        wisp.position = new Vector2(player_pos.x - 1, player_pos.y + 2);
    }
}
