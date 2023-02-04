using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        GameObject player = GameObject.Find("Player");
        float yVelocity = player.GetComponent<Rigidbody2D>().velocity.y;
        Debug.Log(yVelocity);
        if(col.gameObject.tag == "Tall" && yVelocity == 0){
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(RespawnPlatform());
        }
    }

    IEnumerator RespawnPlatform(){
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

}
