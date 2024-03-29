using UnityEngine;
using LootLocker.Requests;

public class GameData : MonoBehaviour
{
    private const string playerKey = "playerData";
    private const string upgradeKey = "upgradeData";
    private int bestScore;
    private int starshipID;
    private const int leaderboardID = 9284;

    private void Start()
    {
        SetPlayerData();
    }

    private void SetPlayerData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);

        bestScore = playerData.BestScore;
        starshipID = playerData.StarshipID;

        СharacterSpawn characterSpawn = this.GetComponent<СharacterSpawn>();
        characterSpawn.starshipID = starshipID;
        characterSpawn.enabled = true;
        Money money = this.GetComponent<Money>();
        money.countMoney = playerData.Money;
        money.enabled = true;
    }

    public void SetUpgradeData(GameObject starshipGO)
    {
        var upgradeData = DataManager.Load<UpgradeData>(upgradeKey);

        Health health = this.GetComponent<Health>();
        health.countHealth = upgradeData.Health;
        health.enabled = true;
        СharacterAttack characterAttack = starshipGO.GetComponent<СharacterAttack>();
        characterAttack.fireRate = upgradeData.FireRate;
        characterAttack.aimAssistance = upgradeData.AimAssistance;
        characterAttack.enabled = true;
    }

    public void SaveData()
    {
        DataManager.Save(playerKey, GetSaveData());
        SubmitScore();
    }

    private PlayerData GetSaveData()
    {
        Money money = this.GetComponentInChildren<Money>();
        int GetBestScore(int score, int bestScore) => score > bestScore ? score : bestScore;
        var data = new PlayerData()
        {
            BestScore = GetBestScore(this.GetComponentInChildren<Score>().countScore, bestScore),
            Money = money.countMoney + money.countMoneyGame,
            StarshipID = starshipID
        };
        return data;
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(PlayerPrefs.GetString("PlayerID"), this.GetComponentInChildren<Score>().countScore, leaderboardID, (response) =>
        {
            if (response.statusCode != 200)
            {
                Debug.Log("ERROR: submit score");
            }
        });
    }
}
