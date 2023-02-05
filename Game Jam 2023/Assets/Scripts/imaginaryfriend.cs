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
    private bool cursorControl;
    private Vector2 cursor_pos;
    private float MoveDelay = 0.01f;

    // Start is called before the first frame update
    void Start(){

        rend = GetComponent<Renderer>();
        rend.enabled = false;
        wisp = GetComponent<Rigidbody2D>();
        player_rb = GameObject.Find("Wisp").GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cursorControl = true;
            cursor_pos = Input.mousePosition;
            wispGoal = cursor_pos;
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            cursorControl = !cursorControl;
        }
        //Makes the wisp move towards its goal
        if(MoveDelay <= 0f){
            gameObject.transform.position = Vector2.MoveTowards(wisp.position, wispGoal, 12f*Time.deltaTime);
            MoveDelay = 0.003f;
        }
        MoveDelay -= Time.deltaTime;
        if(Vector2.Distance(wisp.position, wispGoal) <= 0.5f){
            wisp.velocity = new Vector2(0f, 0f);
        }
        

    }
}
