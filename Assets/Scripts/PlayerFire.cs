using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPos;

    public void Fire(Transform enemy) {
        GameObject newBullet = Instantiate(bullet, bulletSpawnPos.position, bullet.transform.rotation);
        Bullet bulletScript = newBullet.GetComponent<Bullet>();
        bulletScript.SetTarget(enemy);
    }
}
