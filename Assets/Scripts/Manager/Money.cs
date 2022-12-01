using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField]
    private Text moneyObject;
    public int countMoney;
    public int countMoneyGame;

    private void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        moneyObject.text = countMoney + "+" + countMoneyGame;
    }
}
