using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : CharacterState
{
    [SerializeField] float moveSpeed = 5f;
    public bool isFightingWithBoss;
    string enemy;
    public Vector2 inputVec;
    public Vector3 moveVec;

    Joystick joystick;
    private void Start()
    {
        joystick = CanvasManager.instance.joystick;
    }
    protected IEnumerator Idle()        // 대기 상태
    {
        while (!changeState)
        {
            if (joystick.isMoving)   // 움직이면
            {
                SetState(StateFSM.Walk);            // 걷기 상태로 전환
            }else if (player.attackBtnPressed)      // 공격 키를 누르면
            {
                SetState(StateFSM.BaseAttack);      // 공격 상태로 전환
            }
            yield return null;
        }
    }
    protected IEnumerator Walk()        // 걷기 상태
    {
        while (!changeState)
        {
            MovingController.LookDirection(transform, player.moveDir);
            MovingController.RigidMovePos(transform, player.moveDir, moveSpeed);
            if(!joystick.isMoving) SetState(StateFSM.Idle);
            if (player.attackBtnPressed) SetState(StateFSM.BaseAttack);
            yield return null;
        }
    }
    protected IEnumerator BaseAttack()      // 기본 공격
    {
        while (!changeState)
        {
            if (!player.attackBtnPressed)
            {
                if (!joystick.isMoving)
                {
                    SetState(StateFSM.Idle);
                }
                else
                {
                    SetState(StateFSM.Walk);
                }
                yield return new WaitForSeconds(0.3f);
                player.coll.enabled = false;
            }
            yield return null;
        }
    }
}
