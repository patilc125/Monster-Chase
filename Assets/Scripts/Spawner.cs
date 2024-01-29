using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference ;
    
    private GameObject spawnemonster;
    
    [SerializeField]
    private Transform leftPos,rightPos;
    
    private int randomIndex;
    private int randomSide;
   
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }
    
    IEnumerator SpawnMonsters(){
         while(true){

yield return new WaitForSeconds(Random.Range(1,5));
         randomIndex=Random.Range(0,monsterReference.Length);
         randomSide=Random.Range(0,2);
         spawnemonster =Instantiate(monsterReference[randomIndex]);
         if(randomSide==0){
             spawnemonster.transform.position=leftPos.position;
             spawnemonster.GetComponent<Monster>().speed=Random.Range(4,10);
         }else{
             spawnemonster.transform.position=rightPos.position;
             spawnemonster.GetComponent<Monster>().speed=-Random.Range(4,10);
             spawnemonster.transform.localScale=new Vector3(-1f,1f,1f);
         }

              }
   }
}
 