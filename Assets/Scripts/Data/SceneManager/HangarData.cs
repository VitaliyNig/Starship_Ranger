using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarData : MonoBehaviour
{
    private const string playerKey = "playerData";
    private const string starshipKey = "starshipData";

    private void Start()
    {
        SetPlayerData();
    }

    private void SetPlayerData()
    {
        СharacterSpawn characterSpawn = this.GetComponent<СharacterSpawn>();
        characterSpawn.starshipID = GetStarshipIdData();
        characterSpawn.enabled = true;
    }

    public int GetStarshipIdData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);

        int starshipID = playerData.StarshipID;
        return starshipID;
    }

    public List<int> GetUnlockStarshipData()
    {
        var starshipData = DataManager.Load<StarshipData>(starshipKey);

        List<int> unlockStarshipList = new List<int>();
        if (starshipData.Starship0)
        {
            unlockStarshipList.Add(0);
        }
        if (starshipData.Starship1)
        {
            unlockStarshipList.Add(1);
        }
        if (starshipData.Starship2)
        {
            unlockStarshipList.Add(2);
        }
        if (starshipData.Starship3)
        {
            unlockStarshipList.Add(3);
        }
        if (starshipData.Starship4)
        {
            unlockStarshipList.Add(4);
        }
        if (starshipData.Starship5)
        {
            unlockStarshipList.Add(5);
        }
        return unlockStarshipList;
    }

    public void SaveStarshipID(int starshipID)
    {
        DataManager.Save(playerKey, GetSaveData(starshipID));
    }

    private PlayerData GetSaveData(int starshipID)
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);

        var data = new PlayerData()
        {
            Money = playerData.Money,
            BestScore = playerData.BestScore,
            StarshipID = starshipID
        };
        return data;
    }
}
