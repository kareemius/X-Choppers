using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [SerializeField] float speed = 10.0f;
    [SerializeField] float stoppingDistance;     //higher the number, the farther away the enemy will stop
    [SerializeField] float retreatingDistance; //higher the number, the enemy will back away from target at a farther distance
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingRight = false;
    [SerializeField] int health = 100; 
    [SerializeField] Animator anim;
    [SerializeField] bool isCoutinuous;

// The following consts are states represented within the animation state machine, which generate the respective animations.
    const int IDLE = 1;                         // state for when enemy is moving/idle
    const int DAMAGE = 5;                       // state for when enemy takes damage 
    const int DEATH = 0;                        // for when enemy dies.


    public Transform target;        // reference to the enemy's target, the 1P Heli tagged with "Player"
   // public GameObject deathEffect = FindGameObjectWithTag("Death").GetComponent<Animator>();    
    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // records location (Transform params) of Player
        rigid = GetComponent<Rigidbody2D>();
                
        if (anim == null)                       // Make sure anim always starts with some state of animation
            anim = GetComponent<Animator>();
            anim.SetInteger("motion", IDLE);  // Sets the animation to the idle state.
    }
    

    // Update is called once per frame
    void Update() {
         if (Vector2.Distance(transform.position, target.position) > stoppingDistance) { // if the distance between the player and enemy is great
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // have the enemy Move Towards the player using the enemy's and player's position
        } 
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatingDistance) {// if enemy is near enough to the player
            transform.position = this.transform.position; // have the enemy stop moving by setting it's current position.
        }
        
        else if (Vector2.Distance(transform.position, target.position) < retreatingDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime); //
        }
      
        if (target.position.x >= transform.position.x)  {
            Flip();
        }
    
    }
/*
    void FixedUpdate() {
         /* make new vector to record target's rotation
         the following if statement checks how far player is from enemy 
         Inside V2.Distance is enemy's position and players position
         If the enemy is far from the player, the enemy will move towards player's position
         if (Vector2.Distance(transform.position, target.position) > stoppingDistance) { // if the distance between the player and enemy is great
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // have the enemy Move Towards the player using the enemy's and player's position
        } 
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatingDistance) {// if enemy is near enough to the player
            transform.position = this.transform.position; // have the enemy stop moving by setting it's current position.
        }
        
        else if (Vector2.Distance(transform.position, target.position) < retreatingDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime); //
        }
      
        if (target.position.x >= transform.position.x ) {
            Flip();
        }
       
    }
*/
    void Flip(){
        // if target passes enemy rigidbody at certain point relative to rigidbody position
        Vector2 rotation = new Vector2(transform.eulerAngles.x, target.transform.eulerAngles.y);
        transform.rotation = Quaternion.Euler(rotation);
        //isFacingRight = !isFacingRight;
        //transform.Rotate(0,180,0);
    }

    public void TakeDamage (int damage) {
        anim.SetInteger("motion", DAMAGE);
        StartCoroutine(InitializeParameter());
        health -= damage;
            if (health <= 0 ) {
                Die();
            }
   }

   void Die() {
     //    Instantiate(deathEffect, transform.position, Quaternion.identity);
        anim.SetInteger("motion", DEATH);
        Destroy(gameObject);
        
   }

   IEnumerator InitializeParameter(){ 
　　 //Need a flame for switching animation.
    //Without this the above method can't switch a state.
    yield return null;
    isCoutinuous = false;
　　 anim.SetInteger("motion", IDLE);
    }

}