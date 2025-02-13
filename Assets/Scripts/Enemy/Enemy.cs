using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    public Player player;
    public bool isHitCool;
    float hitCooltime;

    protected override void Awake()
    {
        base.Awake();
        hitCooltime = 0.267f;
    }
    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);

        //DamageText damageText
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BaseAttack") && !isHitCool)
        {
            GetDamage(damage);
            StartCoroutine(HitCooltime());
        }
    }
    IEnumerator HitCooltime()
    {
        isHitCool = true;
        yield return new WaitForSeconds(hitCooltime);
        isHitCool = false;
    }
}
