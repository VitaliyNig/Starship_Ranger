using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Image[] healthObject;
    public int countHealth;
    private Color colorHealth;
    private Color colorDeath;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#FFB958", out colorHealth);
        ColorUtility.TryParseHtmlString("#282828", out colorDeath);
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        foreach (var ho in healthObject)
        {
            ho.color = colorDeath;
        }
        for (int i = 0; i < countHealth; i++)
        {
            healthObject[i].color = colorHealth;
        }
    }
}
