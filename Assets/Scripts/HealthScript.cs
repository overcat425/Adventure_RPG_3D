using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Text;
using System.Xml.Linq;

public class HealthScript : MonoBehaviour
{
    private CharacterBase characterBase;
    private CharacterState characterState;

    [Header("Health")]
    public Slider slider;
    Text healthText;
    float currentHp;
    float maxHp;

    StringBuilder healthStr = new StringBuilder();
    private void Awake()
    {
        characterBase = GetComponent<CharacterBase>();
        characterState = GetComponent<CharacterState>();
        healthText = slider.transform.GetChild(2).GetComponent<Text>();
    }
    private void OnEnable()
    {
        if(currentHp == 0)
        {
            maxHp = characterBase.maxHealth;
            currentHp = maxHp;
            slider.value = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        HealthString();
    }
    void HealthString()
    {
        healthStr.Clear();
        healthStr.Append(currentHp).Append(" / ").Append(maxHp);
        healthText.text = healthStr.ToString();
    }
}
