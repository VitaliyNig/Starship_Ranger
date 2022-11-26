using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    private const string playerKey = "playerData";
    private const string starshipKey = "starshipData";
    private const string updateKey = "updateData";

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    //ShopScene

    public void BuyUpgradeItem()
    {
        GameObject.Find("EventScripts").GetComponentInChildren<ShopData>().BuyUpgrade(this.name);
    }

    public void BuyStarshipItem()
    {
        GameObject.Find("EventScripts").GetComponentInChildren<ShopData>().BuyStarship(this.name);
    }

    //DevScene

    public void LoadDevScene()
    {
        SceneManager.LoadScene("DevScene");
    }

    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete All PlayerPrefs");
    }

    public void AddMoney()
    {
        DataManager.Save(playerKey, GetAddMoneyData());
    }

    private PlayerData GetAddMoneyData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);

        var data = new PlayerData()
        {
            BestScore = playerData.BestScore,
            Money = playerData.Money + 1000,
            StarshipID = playerData.StarshipID
        };
        Debug.Log("Add Money");
        return data;
    }

    public void DeleteMoney()
    {
        DataManager.Save(playerKey, GetDeleteMoneyData());
    }

    private PlayerData GetDeleteMoneyData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);

        var data = new PlayerData()
        {
            BestScore = playerData.BestScore,
            Money = 0,
            StarshipID = playerData.StarshipID
        };
        Debug.Log("Delete Money");
        return data;
    }

    public void UnlockAllStarship()
    {
        DataManager.Save(starshipKey, GetUnlockStarshipData());
    }

    private StarshipData GetUnlockStarshipData()
    {
        var starshipData = DataManager.Load<StarshipData>(starshipKey);

        var data = new StarshipData()
        {
            Starship0 = true,
            Starship1 = true,
            Starship2 = true,
            Starship3 = true,
            Starship4 = true,
            Starship5 = true
        };
        Debug.Log("Unlock All Starship");
        return data;
    }

    public void UpgradeMax()
    {
        DataManager.Save(updateKey, GetUpgradeMaxData());
    }

    private UpgradeData GetUpgradeMaxData()
    {
        var upgradeData = DataManager.Load<UpgradeData>(updateKey);

        var data = new UpgradeData()
        {
            Health = 5,
            FireRate = 5,
            AimAssistance = 5
        };
        Debug.Log("Unlock Max Upgrade");
        return data;
    }
}
