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

    [Header("Enemy")]
    public GameObject enemyBar;
    float hpVisibleTime, visibleTime = 5f;
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
        //if (gameObject.layer.Equals(6))
        //{
        //    slider = enemyBar.transform.GetChild(2).GetComponent<Slider>();
        //}
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
    private void LateUpdate()
    {
        if (gameObject.layer.Equals(6))
        {
            enemyBar.transform.position = transform.position + new Vector3(0, 2f, 0);
            if (Time.time - hpVisibleTime > visibleTime)
            {
                enemyBar.SetActive(false);  // �ǰ� �� 5�ʰ� ������ �� HP�� false
            }
        }
    }
    void HealthString()
    {
        healthStr.Clear();
        healthStr.Append(currentHp).Append(" / ").Append(maxHp);
        healthText.text = healthStr.ToString();
    }
    public void HpDecrease(float current, float max)
    {
        slider.value = current / max;
        if (gameObject.layer.Equals(6))
        {
            enemyBar.SetActive(true);   // �� �ǰݽ� hp�� true
            hpVisibleTime = Time.time;  // �ǰ� �ð� �޸�
        }
        if (currentHp <= 0) characterState.SetState(StateFSM.Die);  // ü���� 0�̸� ���
    }
}
