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
    private Vector2 wispGoal;
    [SerializeField] private float wispSpeed;

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
            wispGoal = new Vector2(player_pos.x - 1f, player_pos.y + 2f);
        }
        else if (player_rb.velocity.x < 0)
        {
            wispGoal = new Vector2(player_pos.x + 1f, player_pos.y + 2f);
        }
        else { wispGoal = new Vector2(player_pos.x, player_pos.y + 2.5f); }

        if (wisp.position.x < wispGoal.x)
        {
            wisp.velocity = new Vector2(wispSpeed, wisp.velocity.y);
        }
        else if (wisp.position.x > wispGoal.x)
        {
            wisp.velocity = new Vector2(-wispSpeed, wisp.velocity.y);
        }
        else if (wisp.position.x == wispGoal.x)
        {
            wisp.velocity = new Vector2(0f, wisp.velocity.y);
        }

        if (wisp.position.y < wispGoal.y)
        {
            wisp.velocity = new Vector2(wisp.velocity.x, wispSpeed);
        }
        else if (wisp.position.y > wispGoal.y)
        {
            wisp.velocity = new Vector2(wisp.velocity.x, -wispSpeed);
        }
        else if (wisp.position.y == wispGoal.y) 
        { 
            wisp.velocity = new Vector2(wisp.velocity.x, 0f); 
        }
    }
}
