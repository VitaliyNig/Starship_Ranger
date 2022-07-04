using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    private void Start()
    {
        float speed = AsteroidSpawn.asteroidSpeed;
        this.GetComponent<Rigidbody>().AddForce(0f, 0f, -speed, ForceMode.Impulse);
    }
}
