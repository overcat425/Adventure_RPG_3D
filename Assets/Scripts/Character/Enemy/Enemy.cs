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

        GameObject damageObj = GameManager.instance.objectPool.CreateObject(1);
        DamageText damageText = damageObj.GetComponent<DamageText>();
        damageText.DamageAction(damage, transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BaseAttack") && !isHitCool)
        {
            Debug.Log(damage);
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
