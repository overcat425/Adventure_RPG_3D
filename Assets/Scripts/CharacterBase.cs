using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public Rigidbody rigid { get; set; }
    public Animator anim { get; set; }
    protected HealthScript healthScript;
    protected RaycastHit raycastHit;

    public float maxHealth;
    public float currentHealth;
    public float maxExp;
    public float currentExp { get; set; }
    public int baseDamage;      // 최소 데미지
    public float damage { get => Random.Range(baseDamage, baseDamage + 5); }
    public bool isDie { get => currentHealth <= 0; }
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
    }
    public virtual void GetDamage(float damage) // 피격 메소드
    {
        currentHealth -= damage;
        if(currentHealth < 0) currentHealth = 0;
    }
}
