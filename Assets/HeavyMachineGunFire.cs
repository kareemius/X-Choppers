using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMachineGunFire : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int damage = 10;
    [SerializeField] int ammo = 50;
    [SerializeField] AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * speed; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
