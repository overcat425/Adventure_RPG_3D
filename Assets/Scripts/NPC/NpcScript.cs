using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcScript : MonoBehaviour
{
    public Npc npc;
    public GameObject npcUi;
    public Image npcImg;
    public Text npcName;
    public GameObject talkingBtn;
    private void OnTriggerEnter(Collider other)
    {
        talkingBtn.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        talkingBtn.SetActive(false);
    }
    public void OnStartTalkingBtn()
    {
        talkingBtn.SetActive(false);
        npc.ShowNpcTalking();
    }
}
