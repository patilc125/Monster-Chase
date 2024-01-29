using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce=40f;
    public float jumpForce=100f;
  
    private float movementX;
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anin;

   private bool isGrounded;


    void Start()
    {
         myBody=GetComponent<Rigidbody2D>();
         anin=GetComponent<Animator>();
         sr=GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        PlayerMoveKeyboard();
        AninatePlayer();
        PlayerJump();
    }
  
 private void FixedUpdate(){
      PlayerJump();
  }
  void PlayerMoveKeyboard(){
    movementX=Input.GetAxisRaw("Horizontal"); 
    
    transform.position+=new Vector3(movementX,0f,0f)*moveForce*Time.deltaTime;
    
   }
  void AninatePlayer(){
    
    if(movementX!=0){
      anin.SetBool("walk",true);
      if(movementX>0){
	sr.flipX=false;
     }else{
	sr.flipX=true;
   }
    }else{
      anin.SetBool("walk",false);
   }

 }
 void PlayerJump(){
    if(Input.GetButtonDown("Jump")&&isGrounded){
      isGrounded=false;
      myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);;
    }
  }
  private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.CompareTag("Ground")){
      isGrounded=true;
     }
     if(collision.gameObject.CompareTag("Enemie")){
       Destroy(gameObject);
     }
  }
  private void OnTriggerEnter2D(Collision2D collision){
       if(collision.gameObject.CompareTag("Enemie")){
          Destroy(gameObject);
      }
  }
}
