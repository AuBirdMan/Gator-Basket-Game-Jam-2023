using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class imaginaryfriend : MonoBehaviour
{

    private Rigidbody2D wisp_rb;
    private Rigidbody2D player_rb;
    private Vector2 player_pos;
    public GameObject player_go;
    private Renderer rend;
    private Vector2 wispGoal;
    private bool cursorControl;
    private float MoveDelay = 0.01f;
    private Vector2 force;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){

        rend = GetComponent<Renderer>();
        rend.enabled = false;
        wisp_rb = GetComponent<Rigidbody2D>();
        player_rb = GameObject.Find("Wisp").GetComponent<Rigidbody2D>();
        rb = player_go.GetComponent<Rigidbody2D>();
        cursorControl = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Sets wisp to be invisible when player is adult
        if (player_go.transform.GetChild(0).gameObject.activeSelf){rend.enabled = true;}
        else {rend.enabled = false;}

        player_pos = player_go.transform.position;
        

        //Sets the wisp's goal to be above and behind the player when it isn't going towards the cursor
        if (!cursorControl)
        {
            if (player_rb.velocity.x > 0)
            {
                wispGoal = new Vector2(player_pos.x - 1f, player_pos.y + 2f);
            }
            else if (player_rb.velocity.x < 0)
            {
                wispGoal = new Vector2(player_pos.x + 1f, player_pos.y + 2f);
            }
            else { wispGoal = new Vector2(player_pos.x, player_pos.y + 2.5f); }
        }

        //"Fires" the wisp towards the cursor, aka sets the goal to be the cursor
        if (Input.GetMouseButtonDown(0))
        {
            cursorControl = true;
            wispGoal = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (wisp_rb.position == wispGoal)
        {
            cursorControl = false;
        }

        //Makes the wisp move towards its goal
        if (MoveDelay <= 0f){
            gameObject.transform.position = Vector2.MoveTowards(wisp_rb.position, wispGoal, 12f*Time.deltaTime);
            MoveDelay = 0.003f;
        }
        MoveDelay -= Time.deltaTime;
        if(Vector2.Distance(wisp_rb.position, wispGoal) <= 0.5f){
            wisp_rb.velocity = new Vector2(0f, 0f);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "GrapplePoint" && cursorControl)
        {
            rb.AddForce((wisp_rb.position - rb.position).normalized * 2000f);
            cursorControl = false;
        }
    }
}