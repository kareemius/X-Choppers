using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20.0f; // value represents speed of bullet
    [SerializeField] Rigidbody2D rigid; // value will serve as reference for playerBullet Rigidbody
    [SerializeField] int damage = 5;
    

    // Start is called before the first frame update
    // when Bullet is generated, set the velocity instantly. 
    void Start() {
        rigid.velocity = transform.right * speed;   // Moves rigid body along x axis at speed
    }

    

    // When the bullet makes contact with a specific RigidBody, we will confirm it's contact
    // before we do anything else.
    // this function will be called whenever something enters a trigger
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.tag == "Enemy") {

        Debug.Log("Collided");
        EnemyScript enemy = hitInfo.gameObject.GetComponent<EnemyScript>();
    
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        }
    }
    // Update is called once per frame
}
