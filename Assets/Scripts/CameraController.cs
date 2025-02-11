using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public CinemachineFreeLook freeLookCam;
    public InputActionAsset inputActions;
    public InputAction moveAction;
    public InputAction lookAction;
    public float speed = 5f;
    bool isTouch;
    Vector2 moveRot;
    Vector2 touchPos;

    Quaternion pitch;   // y축 중심 회전
    Quaternion yaw;     // z축 중심 회전
    private void Awake()
    {
        speed = 5f;
        //var playerActionMap = inputActions.FindActionMap("Player");
        //moveAction = playerActionMap.FindAction("Move");
        var cameraActionMap = inputActions.FindActionMap("Camera");
        lookAction = cameraActionMap.FindAction("Look");
    }
    private void OnEnable()
    {
        //moveAction.Enable();
        lookAction.Enable();
    }
    private void OnDisable()
    {
        //moveAction.Disable();
        lookAction.Disable();
    }
    private void Update()
    {
        //// 이동 입력 처리
        //Vector2 moveInput = moveAction.ReadValue<Vector2>();
        //HandleMovement(moveInput);

        // 카메라 회전 입력 처리
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        Debug.Log(lookInput);
        HandleCameraRotation(lookInput);
    }

    private void HandleMovement(Vector2 moveInput)
    {
        // 이동 방향 처리
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    private void HandleCameraRotation(Vector2 lookInput)
    {
        // 카메라 회전 처리
        freeLookCam.m_XAxis.Value += moveRot.x * Time.deltaTime;
        freeLookCam.m_YAxis.Value -= moveRot.y * Time.deltaTime;
    }

    //void Touch()
    //{
    //    if (!isTouch) return;
    //    Vector3 eulerAngles = cam.localRotation.eulerAngles;
    //    eulerAngles.x = Mathf.Clamp(eulerAngles.x, -80f, 80f);
    //    pitch = Quaternion.Euler(moveRot.y, 0, 0);
    //    yaw = Quaternion.Euler(0, -moveRot.x, 0);
    //    cam.localRotation = yaw * cam.localRotation;
    //    cam.localRotation = cam.localRotation * pitch;
    //}
    public void OnPointerDown(PointerEventData eventData)
    {
        touchPos = eventData.position;
        isTouch = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        touchPos = Vector2.zero;
        moveRot = Vector2.zero;
        isTouch = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - touchPos;
        value = value.normalized; // 정규화
        moveRot = new Vector2(value.x * 100 * Time.deltaTime, value.y * 100 * Time.deltaTime);
    }
}