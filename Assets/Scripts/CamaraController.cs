using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamaraController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Transform cam;
    public float speed;
    bool isTouch;
    Vector2 moveRot;
    Vector2 touchPos;

    Quaternion pitch;   // y축 중심 회전
    Quaternion yaw;     // z축 중심 회전
    void Start()
    {
        speed = 5f * Time.deltaTime;
    }

    void Update()
    {
        Touch();
    }
    void Touch()
    {
        if (!isTouch) return;
        Vector3 eulerAngles = cam.localRotation.eulerAngles;
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, -80f, 80f);
        pitch = Quaternion.Euler(moveRot.y, 0, 0);
        yaw = Quaternion.Euler(0, -moveRot.x, 0);
        cam.localRotation = yaw * cam.localRotation;
        cam.localRotation = cam.localRotation * pitch;
    }
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
        moveRot = new Vector2 ( value.x * 100 * Time.deltaTime, value.y * 100 * Time.deltaTime );
    }
}