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
        GameObject thisGO = this.gameObject;
        if (tryCheck == false)
        {
            string colliderTag = other.collider.tag;
            if (listTags.Contains(colliderTag))
            {
                tryCheck = true;
                GameObject eventScripts = GameObject.Find("EventScripts");
                switch (colliderTag)
                {
                    case "Bullet":
                        if (this.tag == "Crystal")
                        {
                            Money money = eventScripts.GetComponent<Money>();
                            money.countMoneyGame++;
                            money.UpdateMoney();
                        }
                        DestroyGO(thisGO);
                        break;
                    case "Starship":
                        Health health = eventScripts.GetComponent<Health>();
                        DamageEffect damageEffect = eventScripts.GetComponent<DamageEffect>();
                        if (health.countHealth > 0)
                        {
                            health.countHealth--;
                            health.UpdateHealth();
                            damageEffect.TakeDamage();
                        }
                        DestroyGO(thisGO);
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
        ParticleSystem particleSystem = ParticleSystem.Instantiate(explosionParticle, thisGO.transform.position, Quaternion.identity);
        particleSystem.Play();
        particleSystem.GetComponent<AudioSource>().Play();
        particleSystem.GetComponent<ExplosionForce>().enabled = true;
        Destroy(thisGO);
    }
}
