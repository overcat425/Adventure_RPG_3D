using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyState : CharacterState
{
    private Enemy enemy;
    float moveSpeed = 8f;
    float rotateSpeed = 2f;
    Vector3 playerPos => player.transform.position;
    public float distanceFromPlayer => Vector3.Distance(transform.position, playerPos);
    private bool isPlayerInRange;
    protected override void Awake()
    {
        base.Awake();
        enemy = GetComponent<Enemy>();
    }
    protected IEnumerator Idle()
    {
        while (!changeState)
        {
            if (isPlayerInRange && !player.isDie) SetState(StateFSM.Trace);
            yield return null;
        }
    }
    protected IEnumerator Walk()
    {
        while (!changeState)
        {

            if (isPlayerInRange && !player.isDie) SetState(StateFSM.Trace);
            yield return null;
        }
    }
    protected IEnumerator Trace()
    {
        while (!changeState)
        {
            yield return null;
        }
    }
    protected IEnumerator Attack()
    {
        while (!changeState)
        {
            yield return null;
        }
    }
}
