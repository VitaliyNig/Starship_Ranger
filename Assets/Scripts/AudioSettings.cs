using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private const string settingKey = "settingData";
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;
    [SerializeField]
    private Text masterText;
    [SerializeField]
    private Text musicText;
    [SerializeField]
    private Text sfxText;

    private void Start()
    {
        var settingData = DataManager.Load<SettingData>(settingKey);

        masterSlider.value = settingData.MasterVolume;
        musicSlider.value = settingData.MusicVolume;
        sfxSlider.value = settingData.SFXVolume;
    }

    public void UpdateMasterValue()
    {
        masterText.text = (masterSlider.value * 10).ToString() + "%";
        if (masterSlider.value == 0)
        {
            audioMixer.SetFloat("Master", -80f);
        }
        else
        {
            audioMixer.SetFloat("Master", Mathf.Log10(masterSlider.value / 10) * 30);
        }
    }

    public void UpdateMusicValue()
    {
        musicText.text = (musicSlider.value * 10).ToString() + "%";
        if (musicSlider.value == 0)
        {
            audioMixer.SetFloat("Music", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music", Mathf.Log10(musicSlider.value / 10) * 30);
        }
    }

    public void UpdateSFXValue()
    {
        sfxText.text = (sfxSlider.value * 10).ToString() + "%";
        if (sfxSlider.value == 0)
        {
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value / 10) * 30);
        }
    }

    public void SaveData()
    {
        DataManager.Save(settingKey, GetSaveData());
    }

    private SettingData GetSaveData()
    {
        var data = new SettingData()
        {
            MasterVolume = (int)masterSlider.value,
            MusicVolume = (int)musicSlider.value,
            SFXVolume = (int)sfxSlider.value
        };
        return data;
    }
}
