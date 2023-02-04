using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class imaginaryfriend : MonoBehaviour
{

    private Rigidbody2D wisp;
    private Rigidbody2D player_rb;
    private Vector2 player_pos;
    public GameObject player_go;
    private Renderer rend;

    // Start is called before the first frame update
    void Start(){

        rend = GetComponent<Renderer>();
        rend.enabled = false;
        wisp = GetComponent<Rigidbody2D>();
        player_rb = player_go.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (player_go.transform.GetChild(0).gameObject.activeSelf){rend.enabled = true;}
        else {rend.enabled = false;}

        player_pos = player_go.transform.position;
        if (player_rb.velocity.x > 0)
        {
            wisp.position = new Vector2(player_pos.x - 1, player_pos.y + 2);
        }
        else { wisp.position = new Vector2(player_pos.x + 1, player_pos.y + 2); }
    }
}
