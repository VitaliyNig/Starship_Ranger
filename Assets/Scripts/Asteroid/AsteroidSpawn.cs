using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField]
    private AstreroidLists asteroidsPrefab = new AstreroidLists();
    private Vector3 screenSize;
    [SerializeField]
    private float spawnRate;
    public static float asteroidSpeed = 10f;
    private int asteroidCount = 1;

    [System.Serializable]
    public class AstreroidLists
    {
        public List<AsteroidList> asteroidsLists;
    }

    [System.Serializable]
    public class AsteroidList
    {
        public List<GameObject> asteroidPrefab;
    }

    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(spawnRate);
        for (int i = 0; i < asteroidCount; i++)
        {
            AsteroidCreate();
        }
        StartCoroutine(Timer());
    }

    private void AsteroidCreate()
    {
        int numberList = Random.Range(0, asteroidsPrefab.asteroidsLists.Count);
        GameObject asteroidGO = Instantiate<GameObject>(asteroidsPrefab.asteroidsLists[numberList].asteroidPrefab[Random.Range(0, asteroidsPrefab.asteroidsLists[numberList].asteroidPrefab.Count)]);

        Transform asteroidTransform = asteroidGO.transform;
        asteroidTransform.position = new Vector3(Random.Range(-screenSize.x, screenSize.x), 0f, screenSize.z + Random.Range(3f, 6f));
        asteroidTransform.Rotate(float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), Space.Self);

        asteroidGO.GetComponent<Rigidbody>().AddForce(0f, 0f, -asteroidSpeed, ForceMode.Impulse);
    }
}
