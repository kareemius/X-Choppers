using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Heli_1P : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] float vMovement;   // vertical movement between -1 and 1
    [SerializeField] float hMovement;   // horizontal movement between -1 and 1
    [SerializeField] Rigidbody2D rigid;        // variable for RigidBody2D component, property of RigidBody2D
    [SerializeField] float speed = 10.0f;      // gives 1Pheli speed when multiplied by movement
    [SerializeField] bool isFacingRight = true; // by default rigidbody2D rigid faces right
    [SerializeField] Animator anim;             // object to generate states of animation for our sprite
    public Weapon weapon; 

    // The following consts are states represented within the animation state machine, which generate the respective animations.
    const int IDLE = 1;                         // state for when player is moving/idle
    const int DAMAGE = 5;                       // state for when player takes damage 
    const int DEATH = 0;                        // for when player dies.
    
    AudioSource machineGunClip;

    void Start() {
        if (rigid == null) { 
            rigid = GetComponent<Rigidbody2D>();    //edit attributes of rigidbody2D 
        }

        if (anim == null) {                    // Make sure anim always starts with some state of animation
            anim = GetComponent<Animator>();
            anim.SetInteger("motion", IDLE);  // Sets the animation to the idle state.
         }  

         weapon = GetComponent<Weapon>();
         machineGunClip = GetComponent<AudioSource>();
    }
     /* void Update - called once per frame
    - Here we are checking for user input via an arrow key. Input.getAxis("Horizontal") will Look for user input along the horizontal axis and put it in a variable called hMovement
    - This will capture movement with the left and right arrow buttons and give it a variable count between -1 and 1 depending on the button pressed.
      -1 and 0 for left(left arrow key) movement, 0 and 1 for right(right arrow) movement. */
    void Update() {
        vMovement = Input.GetAxis("Vertical");      //assigns vertical movement         
        hMovement = Input.GetAxis("Horizontal");    //assigns horizontal movement
    }
    /* FixedUpdate can be called multiple times per frame, will turn our button presses into physical movement
    First we set the velocity attribute of our RigidBody2D component. Velocity has two elements: an x value and a y value, 
    so we will make a new 2D Vector to store our velocity called Vector2. Vector2 contain only two elements since it is representative of the 2d space, x and y.
    If our rigidbody property is moving left (movement < 0), or if it's moving right and happens to be facing the wrong way (!isfacingright)
    We want to flip our RigidBody object to reflect the direction it's moving. */
    void FixedUpdate() {
        rigid.velocity = new Vector2(hMovement*speed, vMovement*speed);
        if (hMovement < 0 && isFacingRight || hMovement > 0 && !isFacingRight)
        Flip();
    }

    void Flip() {
        transform.Rotate(0,180,0);
        isFacingRight = !isFacingRight;
    }
}

