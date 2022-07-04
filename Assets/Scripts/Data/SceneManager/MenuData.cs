using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuData : MonoBehaviour
{
    [SerializeField]
    private Text bestScore;
    private const string playerKey = "playerData";
    private const string starshipKey = "starshipData";

    private void Start()
    {
        if(PlayerPrefs.HasKey(playerKey))
        {
            LoadData();
        }
        else
        {
            DefaultData();
        }
    }

    private void DefaultData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);
        DataManager.Save(playerKey, playerData);
        var starshipData = DataManager.Load<StarshipData>(starshipKey);
        DataManager.Save(starshipKey, starshipData);
        SetData(playerData);
    }

    private void LoadData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);
        SetData(playerData);
    }

    private void SetData(PlayerData playerData)
    {
        СharacterSpawn characterSpawn = this.GetComponent<СharacterSpawn>();
        characterSpawn.starshipID = playerData.StarshipID;
        characterSpawn.enabled = true;
        bestScore.text = "Best Score: " + playerData.BestScore;
    }
}
