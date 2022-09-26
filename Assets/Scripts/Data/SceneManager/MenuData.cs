using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuData : MonoBehaviour
{
    [SerializeField]
    private Text bestScore;
    [SerializeField]
    private AudioMixer audioMixer;
    private const string playerKey = "playerData";
    private const string settingKey = "settingData";

    private void Start()
    {
        SetData();
    }

    private void SetData()
    {
        var playerData = DataManager.Load<PlayerData>(playerKey);
        var settingData = DataManager.Load<SettingData>(settingKey);

        СharacterSpawn characterSpawn = this.GetComponent<СharacterSpawn>();
        characterSpawn.starshipID = playerData.StarshipID;
        characterSpawn.enabled = true;
        bestScore.text = "Best Score: " + playerData.BestScore;

        if (settingData.MasterVolume == 0)
        {
            audioMixer.SetFloat("Master", -80f);
        }
        else
        {
            audioMixer.SetFloat("Master", Mathf.Log10((float)settingData.MasterVolume / 10) * 30);
        }

        if (settingData.MusicVolume == 0)
        {
            audioMixer.SetFloat("Music", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music", Mathf.Log10((float)settingData.MusicVolume / 10) * 30);
        }

        if (settingData.SFXVolume == 0)
        {
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10((float)settingData.SFXVolume / 10) * 30);
        }
    }
}
