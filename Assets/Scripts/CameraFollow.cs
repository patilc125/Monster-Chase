using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform player;
    private Vector3 temPos;

    void Start()
    {
        player=GameObject.FindWithTag("Player").transform;
    }

   
    void LateUpdate()
    {
       if(!player){
         return ;
       }
       temPos=transform.position;
       temPos.x=player.position.x;
       transform.position=temPos; 
    }
}
