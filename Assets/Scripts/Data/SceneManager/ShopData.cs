using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopData : MonoBehaviour
{
    private const string playerKey = "playerData";
    private const string starshipKey = "starshipData";
    private const string upgradeKey = "upgradeData";
    [SerializeField]
    private GameObject upgradesPrefab;
    [SerializeField]
    private GameObject starshipsPrefab;
    [SerializeField]
    private Transform upgradesParent;
    [SerializeField]
    private Transform starshipsParent;
    [SerializeField]
    private List<Sprite> spriteList;
    [SerializeField]
    private Text moneyObject;
    private int countMoney;

    private class Upgrades
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Level { get; set; }
    }

    private List<Upgrades> upgradesList = new List<Upgrades>()
    {
        new Upgrades{ Name = "Health", Price = 100 },
        new Upgrades{ Name = "Fire Rate", Price = 100 },
        new Upgrades{ Name = "Aim Assistance", Price = 100}
    };

    private class Starships
    {
        public int StarshipID { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
    }

    private List<Starships> starshipsList = new List<Starships>()
    {
        new Starships{ StarshipID = 0, Price = 300},
        new Starships{ StarshipID = 1, Price = 300},
        new Starships{ StarshipID = 2, Price = 300},
        new Starships{ StarshipID = 3, Price = 300},
        new Starships{ StarshipID = 4, Price = 300},
        new Starships{ StarshipID = 5, Price = 300}
    };

    private void Awake()
    {
        SetUpgradeData();
        SetStarshipData();
        SetMoney();
    }

    private void SetUpgradeData()
    {
        var upgradeData = DataManager.Load<UpgradeData>(upgradeKey);

        upgradesList[0].Level = upgradeData.Health;
        upgradesList[1].Level = upgradeData.FireRate;
        upgradesList[2].Level = upgradeData.AimAssistance;

        UpdateUpgradeData();
    }

    private void SetStarshipData()
    {
        var starshipData = DataManager.Load<StarshipData>(starshipKey);

        starshipsList[0].Status = starshipData.Starship0;
        starshipsList[1].Status = starshipData.Starship1;
        starshipsList[2].Status = starshipData.Starship2;
        starshipsList[3].Status = starshipData.Starship3;
        starshipsList[4].Status = starshipData.Starship4;
        starshipsList[5].Status = starshipData.Starship5;

        UpdateStarshipData();
    }

    private void SetMoney()
    {
        countMoney = DataManager.Load<PlayerData>(playerKey).Money;
        UpdateMoney();
    }

    private void UpdateUpgradeData()
    {
        try
        {
            foreach (Transform children in upgradesParent.transform)
            {
                Destroy(children.gameObject);
            }
        }
        catch { }

        foreach (var ul in upgradesList)
        {
            GameObject upgradeGO = Instantiate(upgradesPrefab, upgradesParent);
            Text[] texts = upgradeGO.GetComponentsInChildren<Text>();
            texts[1].text = (ul.Price * ul.Level).ToString();
            texts[2].text = ul.Name;

            Toggle[] toggles = upgradeGO.GetComponentsInChildren<Toggle>();
            for (int c = 0; c < ul.Level; c++)
            {
                toggles[c].isOn = true;
            }

            Button button = upgradeGO.GetComponentInChildren<Button>();
            button.name = ul.Name;
            if (ul.Level >= 5)
            {
                button.interactable = false;
                texts[1].text = "‒";
            }
        }
    }

    private void UpdateStarshipData()
    {
        try
        {
            foreach (Transform children in starshipsParent.transform)
            {
                Destroy(children.gameObject);
            }
        }
        catch { }

        foreach (var sl in starshipsList)
        {
            GameObject starhipsGO = Instantiate(starshipsPrefab, starshipsParent);
            Text[] texts = starhipsGO.GetComponentsInChildren<Text>();
            texts[1].text = sl.Price.ToString();
            starhipsGO.GetComponentInChildren<Image>().sprite = spriteList[sl.StarshipID];

            Button button = starhipsGO.GetComponentInChildren<Button>();
            button.name = sl.StarshipID.ToString();
            if (sl.Status == true)
            {
                button.interactable = false;
                texts[1].text = "‒";
            }
        }
    }

    public void UpdateMoney()
    {
        moneyObject.text = countMoney.ToString();
    }

    public void BuyUpgrade(string name)
    {
        Upgrades upgrade = upgradesList.Find(x => x.Name == name);
        int price = upgrade.Level * upgrade.Price;

        if (countMoney >= price)
        {
            countMoney -= price;
            int index = upgradesList.IndexOf(upgrade);
            upgradesList[index].Level++;
        }

        UpdateUpgradeData();
        UpdateMoney();
    }

    public void BuyStarship(string name)
    {
        Starships starship = starshipsList.Find(x => x.StarshipID.ToString() == name);
        int price = starship.Price;

        if (countMoney >= price)
        {
            countMoney -= price;
            int index = starshipsList.IndexOf(starship);
            starshipsList[index].Status = true;
        }

        UpdateStarshipData();
        UpdateMoney();
    }

    private void OnApplicationPause(bool applicationPause)
    {
        if (applicationPause)
        {
            SaveAllData();
        }
    }

    public void SaveAllData()
    {
        DataManager.Save(upgradeKey, SaveUpgradeData());
        DataManager.Save(starshipKey, SaveStarshipData());
        DataManager.Save(playerKey, SavePlayerData());
    }

    private UpgradeData SaveUpgradeData()
    {
        var upgradeData = DataManager.Load<UpgradeData>(upgradeKey);

        var data = new UpgradeData()
        {
            Health = upgradesList[0].Level,
            FireRate = upgradesList[1].Level,
            AimAssistance = upgradesList[2].Level
        };
        return data;
    }

    private StarshipData SaveStarshipData()
    {
        var starshipData = DataManager.Load<StarshipData>(starshipKey);

        var data = new StarshipData()
        {
            Starship0 = starshipsList[0].Status,
            Starship1 = starshipsList[1].Status,
            Starship2 = starshipsList[2].Status,
            Starship3 = starshipsList[3].Status,
            Starship4 = starshipsList[4].Status,
            Starship5 = starshipsList[5].Status
        };
        return data;
    }

    private PlayerData SavePlayerData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);

        var data = new PlayerData()
        {
            Money = countMoney,
            BestScore = playerData.BestScore,
            StarshipID = playerData.StarshipID
        };
        return data;
    }
}
