using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionParticlePrefab;
    private bool tryCheck = false;
    private List<string> listTags = new List<string> { "Bullet", "Starship", "TriggerAsteroid" };

    private void OnCollisionEnter(Collision other)
    {
        if (tryCheck == false)
        {
            GameObject thisGO = this.gameObject;
            string colliderTag = other.collider.tag;
            if (listTags.Contains(colliderTag))
            {
                tryCheck = true;
                switch (colliderTag)
                {
                    case "Bullet":
                        /*
                        if (thisGO.tag == "Crystal")
                        {
                            
                            Money money = GameObject.Find("CountMoney").GetComponent<Money>();
                            money.countMoney++;
                            money.UpdateMoney();
                            
                        }
                        DestroyGO(thisGO);
                        */
                        break;
                    case "Starship":
                        /*
                        if (GameObject.Find("CountHealth").GetComponent<Health>().countHealth > 1)
                        {
                            DestroyGO(thisGO);
                        }
                        */
                        break;
                    case "TriggerAsteroid":
                        Destroy(thisGO);
                        break;
                }
            }
        }
    }

    private void DestroyGO(GameObject thisGO)
    {
        ParticleSystem explosionParticle = explosionParticlePrefab.GetComponentInChildren<ParticleSystem>();
        ParticleSystem ps = ParticleSystem.Instantiate(explosionParticle, thisGO.transform.position, Quaternion.identity);
        ps.Play();
        ps.GetComponent<AudioSource>().Play();
        Destroy(thisGO);
    }
}
