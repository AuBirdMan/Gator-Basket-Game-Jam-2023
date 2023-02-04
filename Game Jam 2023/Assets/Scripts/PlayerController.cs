using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpThrust;
    private Rigidbody2D rb;
    private float horizontalMovement;
    private float maxVelocity = 20f;
    [SerializeField] private LayerMask groundObject;
    private BoxCollider2D currentCollider;
    private bool isLittle;
    // Start is called before the first frame update
    void Start()
    {
        isLittle = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentCollider = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets left right movement
        horizontalMovement = Input.GetAxis("Horizontal") * speed;
        //if the player just started moving, give them small initial boost of momentum
        //else just add velocity until max velocity is hit
        if(rb.velocity.x <= maxVelocity && rb.velocity.x >= -maxVelocity ){
            rb.velocity += new Vector2(horizontalMovement, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.AddForce(transform.up * jumpThrust, ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            isLittle = !isLittle;
            if(isLittle){
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                currentCollider = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
            }
            else{
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                currentCollider = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
                
            }
        }
       
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(currentCollider.bounds.center, currentCollider.bounds.size, 0f, Vector2.down, 0.1f, groundObject);
    }
}
