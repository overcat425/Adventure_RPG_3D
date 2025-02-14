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
        if(currentHp == 0)  // 체력 초기화
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
        if (gameObject.layer.Equals(6)) // enemy면 health바 머리위 고정
        {
            slider.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            slider.transform.forward = Camera.main.transform.forward;
            if (Time.time - hpVisibleTime > visibleTime)
            {
                slider.gameObject.SetActive(false);  // 피격 후 5초가 지나면 적 HP바 false
            }
        }
    }
    void HealthString() // 체력바 갱신
    {
        slider.DOValue(currentHp / maxHp, 1f);
        healthStr.Clear();
        healthStr.Append(currentHp).Append(" / ").Append(maxHp);
        healthText.text = healthStr.ToString();
    }
    public void HpDecrease(float current, float max)    // 피격 수치 적용
    {
        currentHp = current;
        maxHp = max;
        slider.value = currentHp / maxHp;
        if (gameObject.layer.Equals(6))
        {
            slider.gameObject.SetActive(true);   // 적 피격시 hp바 true
            hpVisibleTime = Time.time;  // 피격 시간 메모
        }
        if (currentHp <= 0) characterState.SetState(StateFSM.Die);  // 체력이 0이면 사망
    }
}
