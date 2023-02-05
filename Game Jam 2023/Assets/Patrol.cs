using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D enimyrb;
    public Vector3 pos1, pos2;
    public float enimySpeed = 5f;
    private Vector3 targetPos;
    private SpriteRenderer enimySprite;
    private GameObject player;

    void Start(){
        enimyrb = gameObject.GetComponent<Rigidbody2D>();
        enimyrb.velocity = -Vector2.right*enimySpeed;
        targetPos = pos1;
        enimySprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if(!player.transform.GetChild(0).gameObject.activeInHierarchy){
            enimySprite.enabled = false;
        }
        else{
            enimySprite.enabled = true;
        }
        if(targetPos == pos1){
            enimyrb.velocity = -Vector2.right*enimySpeed;
            enimySprite.flipX = false;
        }
        else if(targetPos == pos2){
            enimyrb.velocity = Vector2.right*enimySpeed;
            enimySprite.flipX = true;
        }

        if(gameObject.transform.position.x < pos1.x){
            targetPos = pos2;
        }
        else if(gameObject.transform.position.x > pos2.x){
            targetPos = pos1;
        }
    }
}
