using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScene;
    [SerializeField]
    private Button respawnButton;
    [SerializeField]
    private int respawnMoney;
    [SerializeField]
    private int respawnCount;
    private Color colorBlue;
    private int countRespawnMoney;

    public void ActivateScene()
    {
        gameOverScene.SetActive(true);
        respawnCount++;
        countRespawnMoney = respawnMoney * respawnCount;
        Text respawnButtonText = respawnButton.GetComponentInChildren<Text>();
        if (countRespawnMoney > this.GetComponent<Money>().countMoney)
        {
            ColorUtility.TryParseHtmlString("#B1E0FF", out colorBlue);
            respawnButton.interactable = false;
            respawnButtonText.color = colorBlue;
        }
        respawnButtonText.text = "Continue for " + countRespawnMoney.ToString() + "m";
    }

    public void ContinueGame()
    {
        gameOverScene.SetActive(false);
        Money money = this.GetComponent<Money>();
        money.countMoney = money.countMoney - countRespawnMoney;
        money.UpdateMoney();
        Score score = this.GetComponent<Score>();
        score.GameInPause = false;
        score.StartUpdateScore();
        Health health = this.GetComponent<Health>();
        health.countHealth = 1;
        health.UpdateHealth();

        GameObject[] asteroidObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        GameObject[] crystalObjects = GameObject.FindGameObjectsWithTag("Crystal");
        foreach (var a in asteroidObjects)
        {
            Destroy(a);
        }
        foreach (var c in crystalObjects)
        {
            Destroy(c);
        }

        this.GetComponent<СharacterSpawn>().Reload();
    }
}
