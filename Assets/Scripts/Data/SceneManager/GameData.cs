using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    private const string playerKey = "playerData";

    private void Start() 
    {
        LoadData();
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
        Money money = this.GetComponent<Money>();
        money.countMoney = playerData.Money;
        money.enabled = true;
        Health health = this.GetComponent<Health>();
        health.countHealth = playerData.Health;
        health.enabled = true;
    }

    private void SaveData()
    {

    }
}
