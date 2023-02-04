using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D currentCollider;
    private bool isLittle;

    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isLittle = false;
        currentCollider = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        float rbx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(rbx * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            isLittle = !isLittle;
            if (isLittle)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                currentCollider = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                currentCollider = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();

            }
        }
    }
}
