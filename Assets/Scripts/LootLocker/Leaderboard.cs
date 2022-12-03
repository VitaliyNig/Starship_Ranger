using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private GameObject rowPrefab;
    [SerializeField]
    private GameObject rowPrefabUser;
    [SerializeField]
    private Transform rowsParent;
    private const int leaderboardID = 9284;
    private const int countRow = 999;
    private const int after = 0;
    private GameObject rowGo;

    private void Start()
    {
        string playerID = PlayerPrefs.GetString("PlayerID");

        foreach (Transform row in rowsParent)
        {
            Destroy(row.gameObject);
        }

        LootLockerSDKManager.GetScoreList(leaderboardID, countRow, after, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    if (members[i].player.id.ToString() == playerID)
                    {
                        rowGo = Instantiate(rowPrefabUser, rowsParent);
                    }
                    else
                    {
                        rowGo = Instantiate(rowPrefab, rowsParent);
                    }

                    Text[] texts = rowGo.GetComponentsInChildren<Text>();
                    texts[0].text = members[i].player.name;
                    texts[1].text = members[i].rank.ToString();
                    texts[2].text = members[i].score.ToString();
                }
            }
            else
            {
                Debug.Log("ERROR: " + response.Error);
            }
        });
    }
}
