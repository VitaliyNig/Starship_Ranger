using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheck : MonoBehaviour
{
    [SerializeField]
    private float offsetPosition;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            this.GetComponent<СharacterController>().enabled = true;
            EngineStart();
            SetPosition();
        }
    }

    private void EngineStart()
    {
        this.GetComponent<AudioSource>().Play();
        ParticleSystem[] particleSystems = this.GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in particleSystems)
        {
            ps.Play();
        }
    }

    private void SetPosition()
    {
        Vector3 screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        Vector3 starshipPosition = Vector3.zero;
        starshipPosition.z = -screenSize.z + offsetPosition;
        this.transform.position = starshipPosition;
    }
}