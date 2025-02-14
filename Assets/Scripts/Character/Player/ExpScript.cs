using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ExpScript : MonoBehaviour
{
    public GameObject expBar;
    Image expGauge;
    Text expText;
    float gaugeSpeed;
    float maxExp;
    float currentExp;

    StringBuilder expStr = new StringBuilder();
    private void Awake()
    {
        expGauge = expBar.transform.GetChild(0).GetComponent<Image>();
        expText = expBar.transform.GetChild(1).GetComponent<Text>();

        maxExp = GameManager.instance.player.maxExp;
    }
    void Update()
    {
        ExpString();
    }
    void ExpString()
    {
        expStr.Clear();
        expStr.Append(currentExp).Append(" / ").Append(maxExp);
        expText.text = expStr.ToString();
    }
    public void GetExp(float current, float max)
    {
        currentExp = current / max;
    }
}
