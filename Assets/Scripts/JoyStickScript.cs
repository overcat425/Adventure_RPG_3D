using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] RectTransform joystick;
    [SerializeField] RectTransform handle;
    public Vector2 inputVec;
    Vector2 startPos;
    Vector2 joystickPos;
    float radius;
    public bool isMoving;

    Vector2 GetInputVector() => inputVec;
    void Start()
    {
        radius = 50f;
    }
    public void OnPointerDown(PointerEventData eventData)  // 터치 다운
    {
        startPos = transform.position;
        //OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData) // 터치 업
    {
        isMoving = true;
        handle.anchoredPosition = Vector2.zero;
        inputVec = Vector2.zero;
    }
    public void OnDrag(PointerEventData eventData)  // 터치 후 드래그
    {
        isMoving = false;
        Vector2 dir = eventData.position - startPos;
        float dist = Mathf.Min(dir.magnitude, radius);
        joystickPos = eventData.position + dir.normalized * dist;
        handle.position = joystickPos;
        inputVec = dir.normalized * (dist / radius);  // 0~1로 정규화시킴
    }
}