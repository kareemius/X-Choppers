using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] Transform firePoint; // Value = exact location of FirePoint object. 
    [SerializeField]
    GameObject playerBullet;   // value represents playerBullet prefab 

    GameObject player;

    GameObject currentBullet;
    // Start is called before the first frame update

    void Start() {
        player = GameObject.FindGameObjectWithTag ("Player");
        currentBullet = playerBullet;
    }

    // Update is called once per frame
    // If the Fire1 (Spacebar) is pressed, call the shoot function to fire 1 bullet.
    void Update() {
        if (Input.GetButtonDown("Fire1")){
            // Instatiate generates a game object from our assets, at a set location, and at a set angle
            var bullet = Instantiate(currentBullet, firePoint.position, firePoint.rotation); // Generate playerBullet at 1P_Heli's Firepoint position and rotation
            bullet.GetComponent<Bullet>().PlaySound();
        }
    }

    public void ChangeBullet(GameObject newBullet)
    {
        currentBullet = newBullet;
    }

     
    
    
}
