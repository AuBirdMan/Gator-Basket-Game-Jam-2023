using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    public Animator platformBreakAnim;
    public float TimeTillRespawn = 3f;
    [SerializeField] AudioSource breakSFX;

    void OnCollisionEnter2D(Collision2D col){
        GameObject player = GameObject.Find("Player");
        float yVelocity = player.GetComponent<Rigidbody2D>().velocity.y;
        if(col.gameObject.tag == "Tall" && yVelocity <= 0.01){
            platformBreakAnim.SetBool("Broke", true);
            breakSFX.Play();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(RespawnPlatform());
        }
    }

    IEnumerator RespawnPlatform(){
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(TimeTillRespawn);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        platformBreakAnim.SetBool("Broke", false);
    }

}
