using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hangar : MonoBehaviour
{
    [SerializeField]
    private Button selectButton;
    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button rightButton;
    private int starshipID;
    [SerializeField]
    private int sceneStarshipID;
    [SerializeField]
    private List<int> unlockStarshipList;
    private СharacterSpawn characterSpawn;
    private Color colorBlue;
    private Color colorBlack;

    private void Start()
    {
        HangarData hangarData = this.GetComponent<HangarData>();
        unlockStarshipList = hangarData.GetUnlockStarshipData();
        starshipID = hangarData.GetStarshipIdData();
        sceneStarshipID = starshipID;
        characterSpawn = this.GetComponent<СharacterSpawn>();
        ColorUtility.TryParseHtmlString("#B1E0FF", out colorBlue);
        ColorUtility.TryParseHtmlString("#141414", out colorBlack);
        СheckStatusSelectButton();
        СheckCountItemList();
    }

    private void СheckCountItemList()
    {
        if (unlockStarshipList.Count == 1)
        {
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
    }

    public void ButtonSelect()
    {
        starshipID = sceneStarshipID;
        this.GetComponent<HangarData>().SaveStarshipID(starshipID);
        СheckStatusSelectButton();
    }

    private void СheckStatusSelectButton()
    {
        Text selectButtonText = selectButton.GetComponentInChildren<Text>();
        if (sceneStarshipID == starshipID)
        {
            selectButton.interactable = false;
            selectButtonText.text = "Selected";
            selectButtonText.color = colorBlue;
        }
        else
        {
            if (!selectButton.interactable)
            {
                selectButton.interactable = true;
                selectButtonText.text = "Select";
                selectButtonText.color = colorBlack;
            }
        }
    }

    public void ButtonLeft()
    {
        int countItemList = unlockStarshipList.Count;
        int indexSceneStarshipID = unlockStarshipList.IndexOf(sceneStarshipID);
        if (indexSceneStarshipID == 0)
        {
            sceneStarshipID = unlockStarshipList[countItemList - 1];
        }
        else
        {
            sceneStarshipID = unlockStarshipList[indexSceneStarshipID - 1];
        }
        characterSpawn.starshipID = sceneStarshipID;
        characterSpawn.Reload();
        СheckStatusSelectButton();
    }

    public void ButtonRight()
    {
        int countItemList = unlockStarshipList.Count;
        int indexSceneStarshipID = unlockStarshipList.IndexOf(sceneStarshipID);
        if (indexSceneStarshipID == (countItemList - 1))
        {
            sceneStarshipID = unlockStarshipList[0];
        }
        else
        {
            sceneStarshipID = unlockStarshipList[indexSceneStarshipID + 1];
        }
        characterSpawn.starshipID = sceneStarshipID;
        characterSpawn.Reload();
        СheckStatusSelectButton();
    }
}
