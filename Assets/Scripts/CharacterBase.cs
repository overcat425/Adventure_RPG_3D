using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public Rigidbody rigid { get; set; }
    public Animator anim { get; set; }
    protected HpBar hpBar;
    protected RaycastHit raycastHit;
    public float maxHealth;
    public float currentHealth;
    public float maxExp;
    public float currentExp;
    public int baseDamage;      // 최소 데미지
    public float damage { get => Random.Range(baseDamage, baseDamage + 5); }
    public bool isDie { get => currentHealth <= 0; }
    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
