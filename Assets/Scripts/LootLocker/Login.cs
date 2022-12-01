using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

public class Login : MonoBehaviour
{
    private bool sessionStatus = true;
    private const string key = "TempUsername";
    private const int numberScene = 7;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                sessionStatus = false;
                return;
            }
            Debug.Log("Starting LootLocker session: " + sessionStatus);
        });

        if (!PlayerPrefs.HasKey(key))
        {
            SceneManager.LoadScene(numberScene);
        }
    }
}
