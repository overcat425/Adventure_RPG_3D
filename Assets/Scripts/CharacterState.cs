using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateFSM { Idle, Walk, BaseAttack, Skill, Hit, Die, Trace }
public class CharacterState : MonoBehaviour
{
    protected CharacterBase characterBase;
    protected Player player;
    public StateFSM state { get; set; }
    protected bool changeState { get; set; }
    protected virtual void Awake()
    {
        characterBase = GetComponent<CharacterBase>();
        player = GetComponent<Player>();
    }
    protected virtual void OnEnable()
    {
        state = StateFSM.Idle;
        StartCoroutine(ChangeState());
    }
    IEnumerator ChangeState()   // ���°� �ٲ� ��
    {
        while (true)
        {
            changeState = false;
            yield return StartCoroutine(state.ToString());
        }
    }
    public void SetState(StateFSM newState) // ���°� ���ϸ� �ڽĿ� ����int ����
    {
        if (state != newState)
        {
            changeState = true;
            state = newState;
            characterBase.anim.SetInteger("state", (int)state); 
        }
    }
    protected virtual void Die()    // �״� �ִϸ��̼�
    {

    }
}
