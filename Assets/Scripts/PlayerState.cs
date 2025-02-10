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
    protected IEnumerator Idle()        // ��� ����
    {
        while (!changeState)
        {
            if (joystick.isMoving)   // �����̸�
            {
                SetState(StateFSM.Walk);            // �ȱ� ���·� ��ȯ
            }else if (player.attackBtnPressed)      // ���� Ű�� ������
            {
                SetState(StateFSM.BaseAttack);      // ���� ���·� ��ȯ
            }
            yield return null;
        }
    }
    protected IEnumerator Walk()        // �ȱ� ����
    {
        while (!changeState)
        {
            MovingController.LookDirection(transform, player.moveDir);
            MovingController.RigidMovePos(transform, player.moveDir, moveSpeed);
            //moveVec = new Vector3(inputVec.x, 0, inputVec.y);
            //transform.position = moveVec * moveSpeed * Time.deltaTime;
            //transform.LookAt(moveVec + transform.position);
            if(!joystick.isMoving) SetState(StateFSM.Idle);
            if (player.attackBtnPressed) SetState(StateFSM.BaseAttack);
            yield return null;
        }
    }
    protected IEnumerator Attack()
    {
        yield return null;
    }
}
