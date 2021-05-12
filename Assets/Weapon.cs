using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] Transform firePoint; // Value = exact location of FirePoint object. 
    public GameObject playerBullet;   // value represents playerBullet prefab
    public GameObject HeavyMachineGun; 
    public GameObject heavyMachineGunBullet; 
    public GameObject player;
    public AudioSource audio;
    public GameObject currentBullet;
    // Start is called before the first frame update

    void Start() {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag ("Player");
        currentBullet = playerBullet;
       // heavyMachineGunBullet = GameObject.Find("heavyMachineGunBullet");
    }

    // Update is called once per frame
    // If the Fire1 (Spacebar) is pressed, call the shoot function to fire 1 bullet.
    void Update() {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
            audio.Play();
        }
    }
    // Instatiate generates a game object from our assets, at a set location, and at a set angle
    
    void Shoot() {
        var bullet = Instantiate(currentBullet, firePoint.position, firePoint.rotation); // Generate playerBullet at 1P_Heli's Firepoint position and rotation

    }

     
    
    
}
