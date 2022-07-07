using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class СharacterSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> starshipPrefab;
    private GameObject starshipGO;
    public int starshipID;

    private void Start()
    {
        Reload();
    }

    public void Reload()
    {
        Destroy(starshipGO);
        starshipGO = Instantiate<GameObject>(starshipPrefab[starshipID]);
        if(SceneManager.GetActiveScene().name == "GameScene")
        {
            this.GetComponent<GameData>().SetUpgradeData(starshipGO);
            this.GetComponent<DamageEffect>().SetDamageParameter(starshipGO);
        }
    }
}
