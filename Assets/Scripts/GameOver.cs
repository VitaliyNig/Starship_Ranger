using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScene;

    public void ActivateScene()
    {
        gameOverScene.SetActive(true);
    }
}
