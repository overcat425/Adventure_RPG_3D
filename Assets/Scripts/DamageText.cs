using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private const float lifeTime = 1f;
    float startTime;
    private Text damageText;
    Color damageColor;
    private void Start()
    {
        gameObject.transform.SetParent(CanvasManager.instance.canvas.transform);
    }
    public void DamageAction(float damage, Vector3 pos)
    {
        damageText = gameObject.GetComponent<Text>();
        damageText.text = damage.ToString();
        StartCoroutine(TextAction(pos));
    }

    IEnumerator TextAction(Vector3 pos)
    {
        startTime = Time.time;
        while ( Time.time - startTime < lifeTime)
        {
            damageText.transform.position = Camera.main.WorldToScreenPoint(pos + new Vector3(0, 2f, 0));
            damageText.rectTransform.DOAnchorPosY(transform.position.y + 10f, 1f);
            damageColor.a = Mathf.Lerp(damageColor.a, 0f, 0.8f*Time.deltaTime);
            yield return null;
        }
        damageColor.a = 1f;
        gameObject.SetActive(false);
    }
}
