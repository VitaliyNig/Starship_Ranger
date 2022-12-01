[System.Serializable]
public class SettingData
{
    public int MasterVolume;
    public int MusicVolume;
    public int SFXVolume;

    public SettingData()
    {
        MasterVolume = 5;
        MusicVolume = 5;
        SFXVolume = 5;
    }
}
