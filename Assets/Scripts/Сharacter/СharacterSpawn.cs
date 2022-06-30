using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СharacterSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> starshipPrefab;
    [SerializeField]
    private int starshipId;

    private void Start()
    {
        GameObject starshipGO = Instantiate<GameObject>(starshipPrefab[starshipId]);
    }
}
