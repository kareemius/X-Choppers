using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10.0f; // value represents speed of bullet
    [SerializeField] int damage = 5;
    
    [SerializeField] AudioClip bulletSound;   
    
    Rigidbody2D rigid; // value will serve as reference for playerBullet Rigidbody
    // Start is called before the first frame update
    // when Bullet is generated, set the velocity instantly. 
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * speed;   // Moves rigid body along x axis at speed  
    }

    // When the bullet makes contact with a specific RigidBody, we will confirm it's contact
    // before we do anything else.
    // this function will be called whenever something enters a trigger
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.tag == "Enemy") {
            Debug.Log("Bullet Collided With Enemy");
            EnemyScript enemy = hitInfo.gameObject.GetComponent<EnemyScript>();
        
            if (enemy != null){
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }

    public void PlaySound() {
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
    }
}
