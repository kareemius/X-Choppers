using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Powerup : MonoBehaviour {
  GameObject player;       // reference to Heli_1P class

  [SerializeField] AudioSource audio;       // plays when player collects powerup 

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void OnTriggerEnter2D(Collider2D col) {
    // this isn't player
    if (col.gameObject != player) return;

    AudioSource.PlayClipAtPoint(audio.clip, transform.position);
    ApplyPowerup(player.GetComponent<Heli_1P>());
    Destroy(gameObject);
  }

  public virtual void ApplyPowerup(Heli_1P player) {
    Debug.LogError("USING PARENT CLASS ACCIDENTALLY");
  }
}
