using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColEvent : MonoBehaviour
{
    [Header("対象タグに当たっているか※これはいじらないで")]
    [SerializeField]
    bool ColTrigger = false;
    [Header("判定できる状態か")]
    [SerializeField]
    bool onAction = true;
    [Header("対象タグ名")]
    [SerializeField]
    string tagName = "Player";
    [Header("ゲームマネージャーにも記録するか")]
    [SerializeField]
    bool managerTrg = false;
    [Header("マネージャー内、colTrgを指定するもの")]
    [SerializeField]
    int managerIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == tagName && onAction)
        {
            ColTrigger = true;
            if(managerTrg )
            {
                GManager.instance.colTrg[managerIndex] = true;
            }
        }
        else if (tagName == "" && onAction  && col.tag != "Player" && col.tag != "OnMask" && col.tag != "enemy" && col.tag != "noactive" && col.tag != "Water" && col.tag != "pbullet" && col.tag != "ebullet" && col.tag != "npc")
        {
            ColTrigger = true;
            if (managerTrg)
            {
                GManager.instance.colTrg[managerIndex] = true;
            }
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == tagName && onAction  && !ColTrigger)
        {
            ColTrigger = true;
            if (managerTrg)
            {
                GManager.instance.colTrg[managerIndex] = true;
            }
        }
        else if (tagName == "" && onAction  && !ColTrigger && col.tag != "Player" && col.tag != "OnMask" && col.tag != "enemy" && col.tag != "noactive" && col.tag != "Water" && col.tag != "pbullet" && col.tag != "ebullet" && col.tag != "npc")
        {
            ColTrigger = true;
            if (managerTrg)
            {
                GManager.instance.colTrg[managerIndex] = true;
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Water" && tagName == "")
        {
            GManager.instance.setrg = 10;
        }
        if (col.tag == tagName && onAction)
        {
            ColTrigger = false;
            if (managerTrg)
            {
                GManager.instance.colTrg[managerIndex] = false;
            }
        }
        else if (tagName == "" && onAction  && col.tag != "Player" && col.tag != "OnMask" && col.tag != "enemy" && col.tag != "noactive" && col.tag != "Water" && col.tag != "pbullet" && col.tag != "ebullet" && col.tag != "npc") 
        {
            ColTrigger = false;
            if (managerTrg)
            {
                GManager.instance.colTrg[managerIndex] = false;
            }
        }
    }
}
