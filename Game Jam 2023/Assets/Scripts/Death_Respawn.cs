using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "DeathZone"){
            transform.position = respawnPoint;
        }
        else if(col.gameObject.tag == "RespawnPoint"){
            respawnPoint = col.gameObject.transform.position;
        }
    }
}
