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
    // Start is called before the first frame update
    void Start()
    {
        joystick = CanvasManager.instance.joystick;
    }
    private void FixedUpdate()
    {
        if(GetComponent<CharacterState>().state != StateFSM.BaseAttack && joystick.isMoving)
            moveDir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }
    public void PlayerJump()
    {
        if (isJump) return;
        rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
        isJump = true;
    }
    public void OnClickAttack(bool isPressed)
    {
        attackBtnPressed = isPressed;
    }
}
