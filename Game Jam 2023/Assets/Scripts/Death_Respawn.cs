using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    private bool childActive;
    public ParticleSystem deathParticles;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "DeathZone"){
            if(gameObject.transform.GetChild(0).gameObject.activeInHierarchy){
                childActive = true;
            }
            else if(gameObject.transform.GetChild(1).gameObject.activeInHierarchy){
                childActive = false;
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            deathParticles.Play();
            gameObject.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(Respawn());
        }
        else if(col.gameObject.tag == "RespawnPoint"){
            respawnPoint = col.gameObject.transform.position;
        }
    }

    IEnumerator Respawn(){
        yield return new WaitForSeconds(2f);
        if(childActive){
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else{
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        gameObject.transform.position = respawnPoint;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
        gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
