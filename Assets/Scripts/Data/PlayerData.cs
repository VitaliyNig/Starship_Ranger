using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int BestScore;
    public int Money;
    public int StarshipID;
    public int Health;
    public int FireRate;
    public int AimAssistance;

    public PlayerData()
    {
        StarshipID = 2;
        Health = 1;
        FireRate = 1;
        AimAssistance = 1;
    }
}
