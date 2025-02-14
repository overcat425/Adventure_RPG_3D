using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Text;
using DG.Tweening;

public class HealthScript : MonoBehaviour
{
    private CharacterBase characterBase;
    private CharacterState characterState;
    [Header("Enemy")]
    //[SerializeField] Transform canvasHUD;
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
        //if (gameObject.layer.Equals(6))
        //{
        //    GameObject obj = GameManager.instance.objectPool.CreateObject(0);
        //    obj.transform.SetParent(canvasHUD);
        //    slider = obj.GetComponent<Slider>();
        //    slider.gameObject.SetActive(false);
        //}
        healthText = slider.transform.GetChild(2).GetComponent<Text>();
    }
    private void OnEnable()
    {
        if(currentHp == 0)  // ü�� �ʱ�ȭ
        {
            maxHp = characterBase.maxHealth;
            currentHp = maxHp;
            slider.value = currentHp/maxHp;
        }
    }
    void Update()
    {
        HealthString();
    }
    private void LateUpdate()
    {
        if (gameObject.layer.Equals(6)) // enemy�� health�� �Ӹ��� ����
        {
            slider.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            slider.transform.forward = Camera.main.transform.forward;
            if (Time.time - hpVisibleTime > visibleTime)
            {
                slider.gameObject.SetActive(false);  // �ǰ� �� 5�ʰ� ������ �� HP�� false
            }
        }
    }
    void HealthString() // ü�¹� ����
    {
        slider.DOValue(currentHp / maxHp, 1f);
        healthStr.Clear();
        healthStr.Append(currentHp).Append(" / ").Append(maxHp);
        healthText.text = healthStr.ToString();
    }
    public void HpDecrease(float current, float max)    // �ǰ� ��ġ ����
    {
        currentHp = current;
        maxHp = max;
        slider.value = currentHp / maxHp;
        if (gameObject.layer.Equals(6))
        {
            slider.gameObject.SetActive(true);   // �� �ǰݽ� hp�� true
            hpVisibleTime = Time.time;  // �ǰ� �ð� �޸�
        }
        if (currentHp <= 0) characterState.SetState(StateFSM.Die);  // ü���� 0�̸� ���
    }
}
