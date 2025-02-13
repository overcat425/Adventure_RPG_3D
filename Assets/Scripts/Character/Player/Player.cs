using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : CharacterBase
{
    public int level = 1;

    public Vector3 moveDir;
    public bool isJump;
    public bool attackBtnPressed;
    private Joystick joystick;
    public Collider coll;
    protected override void Awake()
    {
        base.Awake();
        joystick = CanvasManager.instance.joystick;
    }
    private void FixedUpdate()
    {
        OnMove();
    }
    void OnMove()
    {
        if (GetComponent<CharacterState>().state != StateFSM.BaseAttack && joystick.isMoving)
        {
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            forward.y = 0f; forward.Normalize();
            right.y = 0f; right.Normalize();
            moveDir = right * joystick.Horizontal + forward * joystick.Vertical;
        }
    }
    public void OnClickJump()
    {
        if (isJump) return;
        rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
        //anim.SetTrigger("Jump");
        isJump = true;
    }
    public void OnClickAttack(bool isPressed)
    {
        coll.enabled = true;
        attackBtnPressed = isPressed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(3)) isJump = false;
    }
}
