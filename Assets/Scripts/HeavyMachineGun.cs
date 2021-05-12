using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class HeavyMachineGun : MonoBehaviour {
    public GameObject player;       // reference to Heli_1P class
    public GameObject weaponBullet; // reference to Weapon class
    public AudioSource audio;       // plays when player collects powerup 

    // Start is called before the first frame update
    void Start()
    {
        if (player == null){ 
            player = GameObject.FindGameObjectWithTag ("Player");
        }
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }

        //weaponBullet = GetComponent<Weapon>().playerBullet;    
    }

    // Update is called once per frame
    void Update() {}


}
