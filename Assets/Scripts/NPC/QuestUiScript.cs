using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class QuestUiScript : MonoBehaviour
{
    public GameObject questBox;
    void Start()
    {
        StartCoroutine(QuestUiMoving());
    }
    private void LateUpdate()
    {
        Rotating();
    }

    void Rotating()
    {
        questBox.transform.Rotate(0, 100f * Time.deltaTime, 0);
    }
    IEnumerator QuestUiMoving()
    {
        while (true)
        {
            yield return questBox.transform.DOMoveY(questBox.transform.position.y + 0.5f, 1f).SetEase(Ease.InOutSine).WaitForCompletion();
            yield return questBox.transform.DOMoveY(questBox.transform.position.y - 0.5f, 1f).SetEase(Ease.InOutSine).WaitForCompletion();
        }
    }
}
