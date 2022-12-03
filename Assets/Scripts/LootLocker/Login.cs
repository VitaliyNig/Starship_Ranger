using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

public class Login : MonoBehaviour
{
    private const int numberScene = 7;

    private void Awake()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("LootLocker");
        if (audioObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    private void Start()
    {
        GuestLogin();
    }

    private void GuestLogin()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("ERROR: starting LootLocker session");
                return;
            }
            PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
            CheckUsername();
        });
    }

    private void CheckUsername()
    {
        LootLockerSDKManager.GetPlayerName((response) =>
        {
            if (!response.success)
            {
                Debug.Log("ERROR: get LootLocker username");
                return;
            }
            if (response.name == "")
            {
                SceneManager.LoadScene(numberScene);
            }
        });
    }
}
