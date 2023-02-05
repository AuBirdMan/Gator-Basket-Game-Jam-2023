using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpThrust;
    private Rigidbody2D rb;
    private float horizontalMovement;
    [SerializeField] private LayerMask groundObject;
    private BoxCollider2D currentCollider;
    private Animator currentAnimator;
    private GameObject currentGameObject, wisp;
    private bool isLittle;
    public ParticleSystem poofEffect, poofEffect2;
    public GameObject clock;
    private float ClockDelay = 0.75f;
    private bool landControl = false;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource landingSFX;
    [SerializeField] private AudioSource transformSFX;
    [SerializeField] private AudioSource walkSFX;

    // Start is called before the first frame update
    void Start()
    {
        isLittle = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentCollider = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
        this.gameObject.tag = "Tall";
        currentAnimator = gameObject.transform.GetChild(1).GetComponent<Animator>();
        currentGameObject = gameObject.transform.GetChild(1).gameObject;
        wisp = GameObject.Find("Wisp");
        wisp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimator.SetFloat("yVelocity", rb.velocity.y);
        if(rb.velocity.x < 0){
            currentGameObject.GetComponent<SpriteRenderer>().flipX =false;
        }
        else if(rb.velocity.x > 0){
            currentGameObject.GetComponent<SpriteRenderer>().flipX = true;    
        }
        if(rb.velocity.y < -0.001f){
            currentAnimator.SetBool("IsFalling", true);
        }
        else{
            currentAnimator.SetBool("IsFalling", false);
        }

        if(IsGrounded() && (rb.velocity.x > 10 || rb.velocity.x < -10)){
            rb.velocity -= rb.velocity / 2 * Vector2.right;
        }

        if(horizontalMovement != 0){
            currentAnimator.SetBool("IsWalking", true);
        }
        else{
            currentAnimator.SetBool("IsWalking", false);
        }
        //if the player just started moving, give them small initial boost of momentum
        //else just add velocity until max velocity is hit
        //initial movement

        //gets left right movement
        horizontalMovement = Input.GetAxis("Horizontal");
        //movement
        if (horizontalMovement != 0)
        {
            if (IsGrounded()) { walkSFX.volume = 0.6f; }
            rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
        }
        else { walkSFX.volume = 0; }
        //jump
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.AddForce(transform.up * jumpThrust, ForceMode2D.Impulse);
            jumpSFX.Play();
        }
        //swap
        if(Input.GetKeyDown(KeyCode.E)){
            poofEffect.Play();
            clock.SetActive(true);
            clock.transform.localScale = new Vector3(1f, 1f, 1f);
            ClockDelay = 0.75f;
            gameObject.transform.position += new Vector3(0f, 0.7f, 0f);
            isLittle = !isLittle;
            transformSFX.Play();
            //to adult
            if(!isLittle){
                rb.mass = 10;
                jumpThrust = 400;
                rb.drag = 0f;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                currentCollider = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
                currentAnimator = gameObject.transform.GetChild(1).GetComponent<Animator>();
                currentGameObject = gameObject.transform.GetChild(1).gameObject;
                this.gameObject.tag = "Tall";
                wisp.SetActive(false);

            }
            //to kid
            else{
                poofEffect2.Play();
                rb.mass = 1;
                jumpThrust = 50;
                rb.drag = 5f;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                currentCollider = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
                currentAnimator = gameObject.transform.GetChild(0).GetComponent<Animator>();
                currentGameObject = gameObject.transform.GetChild(0).gameObject;
                this.gameObject.tag = "Short";
                wisp.SetActive(true);
                
            }
        }
        if(clock.activeInHierarchy){
            clock.transform.localScale += new Vector3(0.001f, 0.001f, 0f);
        }
        if(ClockDelay <= 0f){
            clock.SetActive(false);
        }

        if (rb.velocity.y < -1f && landControl)
        {
            landControl = false;
        }

    }

    private bool IsGrounded(){
        bool result = Physics2D.BoxCast(currentCollider.bounds.center, currentCollider.bounds.size, 0f, Vector2.down, 0.1f, groundObject);
        if(result){
            currentAnimator.SetBool("IsGrounded", true);
            if (!landControl)
            {
                landControl = true;

                landingSFX.Play();
            }
        }
        else{
            currentAnimator.SetBool("IsGrounded", false);
        }
        return result;
    }
    void FixedUpdate(){
        ClockDelay -=Time.deltaTime;
    }
}
