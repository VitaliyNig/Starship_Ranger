using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int BestScore;
    public int Money;
    public int StarshipID;

    public PlayerData()
    {
        StarshipID = 2;
    }
}
