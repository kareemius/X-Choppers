using UnityEngine;

public class HeavyMachineGunPowerup : Powerup {
  [SerializeField]
  GameObject heavyMachineGunBullet;

  public override void ApplyPowerup(Heli_1P player)
  {
    player.weapon.ChangeBullet(heavyMachineGunBullet);
  }
}