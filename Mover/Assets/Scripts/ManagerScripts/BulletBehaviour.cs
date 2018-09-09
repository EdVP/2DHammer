using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class BulletBehaviour : MonoBehaviour {

    public Player Owner { get; private set; }

    private Rigidbody rb;

    private Vector3 velocity;

    private float lag;

    public float weaponForce = 200f;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SpawnBullet(Player owner, Vector3 originalDirection, float l)
    {
        Owner = owner;

        rb.velocity = originalDirection * weaponForce;

        lag = l;

        rb.position += rb.velocity * lag;

    }
   
}
