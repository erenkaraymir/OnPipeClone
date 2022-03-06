using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager ui_m;

    [SerializeField]
    public GameObject panel;
    [SerializeField]
    private TMP_Text distanca_value;

    [SerializeField]
    private RectTransform health_bar;

    [SerializeField]
    private TMP_Text highScore_text;

    private void Awake()
    {
        ui_m = this;
    }

    public void setPlayerHealth(float health)
    {
        health_bar.localScale = new Vector3(health / 10, 1, 1);
    }

    public void activePanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);

        }
    }

    public void setDistanceValue(float distance)
    {
        distanca_value.text = distance.ToString("f1");
    }

    public void setHighScore()
    {
        highScore_text.text = PlayerPrefs.GetFloat("HighScore").ToString();
    }
}
