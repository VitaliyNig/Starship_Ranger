using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreObject;
    [SerializeField]
    private float rateUpdate;
    public int countScore;
    public bool GameInPause = false;

    private void Start()
    {
        StartUpdateScore();
    }

    public void StartUpdateScore()
    {
        InvokeRepeating("UpdateScore", rateUpdate, rateUpdate);
    }

    private void UpdateScore()
    {
        if (!GameInPause)
        {
            countScore++;
            scoreObject.text = countScore.ToString();
        }
        else
        {
            CancelInvoke("UpdateScore");
        }
    }
}
