using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    private NpcScript npcScript;
    protected Transform trans;

    public string npcName;
    public Sprite npcSprite;
    public SpriteRenderer takingBubble;

    public virtual void ShowNpcTalking()
    {
        npcScript.npcUi.SetActive(true);
        npcScript.npcImg.sprite = npcSprite;
        npcScript.npcName.text = npcName;
    }
}
