using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СharacterDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionParticlePrefab;
    private GameObject thisGO;
    private GameObject eventScripts;

    private void Start()
    {
        eventScripts = GameObject.Find("EventScripts");
        thisGO = this.gameObject;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (eventScripts.GetComponent<Health>().countHealth == 0)
        {
            eventScripts.GetComponent<Score>().GameInPause = true;
            eventScripts.GetComponent<GameOver>().ActivateScene();
            ParticleSystem explosionParticle = explosionParticlePrefab.GetComponentInChildren<ParticleSystem>();
            ParticleSystem particleSystem = ParticleSystem.Instantiate(explosionParticle, thisGO.transform.position, Quaternion.identity);
            particleSystem.Play();
            particleSystem.GetComponent<AudioSource>().Play();
            Destroy(thisGO);
        }
    }
}