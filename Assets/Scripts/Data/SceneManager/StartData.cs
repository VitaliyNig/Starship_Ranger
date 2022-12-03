using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine.SceneManagement;

public class StartData : MonoBehaviour
{
    [SerializeField]
    private Button buttonConfirm;
    [SerializeField]
    private Text textConfirm;
    [SerializeField]
    private InputField inputField;
    private Color colorBlue;
    private Color colorBlack;
    private const int numberScene = 0;

    private void Start()
    {
        СharacterSpawn characterSpawn = this.GetComponent<СharacterSpawn>();
        characterSpawn.starshipID = Random.Range(0, 5);
        characterSpawn.enabled = true;

        ColorUtility.TryParseHtmlString("#B1E0FF", out colorBlue);
        ColorUtility.TryParseHtmlString("#141414", out colorBlack);

        buttonConfirm.interactable = false;
        textConfirm.color = colorBlue;
    }

    public void TextInput()
    {
        buttonConfirm.interactable = true;
        textConfirm.color = colorBlack;
    }

    public void CheckInput()
    {
        if (inputField.text == "" || inputField.text.Length > 20)
        {
            buttonConfirm.interactable = false;
            textConfirm.color = colorBlue;
        }
    }

    public void SetUsername()
    {
        LootLockerSDKManager.SetPlayerName(inputField.text, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("ERROR: set LootLocker username");
                return;
            }
            SceneManager.LoadScene(numberScene);
        });
    }
}