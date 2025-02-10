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
    IEnumerator ChangeState()   // 상태가 바뀔 때
    {
        while (true)
        {
            changeState = false;
            yield return StartCoroutine(state.ToString());
        }
    }
    public void SetState(StateFSM newState) // 상태가 변하면 자식에 상태int 전달
    {
        if (state != newState)
        {
            changeState = true;
            state = newState;
            characterBase.anim.SetInteger("state", (int)state); 
        }
    }
    protected virtual void Die()    // 죽는 애니메이션
    {

    }
}
