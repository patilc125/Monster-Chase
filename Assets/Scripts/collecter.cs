using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecter : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision){

         if(collision.CompareTag("Enemie")||collision.CompareTag("Player")){
        Destroy(collision.gameObject);
    }
  }
}
