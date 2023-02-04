using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpThrust;
    private Rigidbody2D rb;
    private float horizontalMovement;
    private float maxVelocity = 15f;
    [SerializeField] private LayerMask groundObject;
    private BoxCollider2D currentCollider;
    private bool isLittle;
    // Start is called before the first frame update
    void Start()
    {
        isLittle = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentCollider = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
        this.gameObject.tag = "Tall";
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded() && (rb.velocity.x > 10 || rb.velocity.x < -10)){
            rb.velocity -= rb.velocity / 2 * Vector2.right;
        }
        //gets left right movement
        horizontalMovement = Input.GetAxis("Horizontal");
        //if the player just started moving, give them small initial boost of momentum
        //else just add velocity until max velocity is hit
        //initial movement
        if(rb.velocity.x == 0 && horizontalMovement * speed != 0){
            rb.velocity += new Vector2(horizontalMovement * speed * 100, 0f);
        }
        //movement
        if(rb.velocity.x <= maxVelocity && rb.velocity.x >= -maxVelocity ){
            rb.velocity += new Vector2(horizontalMovement * speed, 0f);
            //if jumping and at max velocity
            if(rb.velocity.x > maxVelocity){
                rb.velocity = new Vector2(maxVelocity*horizontalMovement, rb.velocity.y);
            }
        }
        //jump
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.AddForce(transform.up * jumpThrust, ForceMode2D.Impulse);
        }
        //swap
        if(Input.GetKeyDown(KeyCode.E)){
            isLittle = !isLittle;
            //to adult
            if(!isLittle){
                rb.mass = 10;
                jumpThrust = 400;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                currentCollider = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
                this.gameObject.tag = "Tall";
            }
            //to kid
            else{
                rb.mass = 1;
                jumpThrust = 25;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                currentCollider = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
                this.gameObject.tag = "Short";
                
            }
        }
       
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(currentCollider.bounds.center, currentCollider.bounds.size, 0f, Vector2.down, 0.1f, groundObject);
    }
}
