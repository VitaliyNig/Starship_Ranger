using UnityEngine;
using UnityEngine.UI;

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
        if (inputField.text == "")
        {
            buttonConfirm.interactable = false;
            textConfirm.color = colorBlue;
        }
    }
}
