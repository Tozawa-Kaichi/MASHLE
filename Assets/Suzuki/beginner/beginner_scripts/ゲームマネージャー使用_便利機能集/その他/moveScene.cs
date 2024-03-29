﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScene : MonoBehaviour
{
    [Header("[ステージ移動時に]\n判定外のイベントを調べる場合")]
    [SerializeField]
    int outeventid = -1;
    public int outeventinput = 0;
    [Header("室内かどうか")]
    [SerializeField]
    int houseSet = 0;
    [Header("当たった瞬間だけ判定するか")]
    [SerializeField]
    bool entertrg = false;
    [Header("あまり気にしないで")]
    [SerializeField]
    SphereCollider areaspcol = null;
    public float colmax = 128;
    [Header("移動時に音楽を変える場合")]
    [SerializeField]
    AudioSource bgmas = null;
    [SerializeField]
    AudioClip setbgm;
    [Header("移動時の音")]
    [SerializeField]
    AudioClip onese = null;
    [Header("移動時にオンオフの対象オブジェクト")]
    [SerializeField]
    GameObject offobj = null;
    [SerializeField]
    GameObject onobj = null;
    [Header("ドアがあるか")]
    [SerializeField]
    bool doortrg = true;
    [Header("調べるイベント")]
    [SerializeField]
    int eventnumber;
    [Header("イベントの指定箇所、このイベントだったら進むみたいな")]
    [SerializeField]
    int inputEvent = -1;
    public int number = 1;
    [Header("+-するかどうか")]
    [SerializeField]
    bool changetrg = false;
    public bool addtrg = false;
    public bool removetrg = false;
    [Header("移動後行く地点")]
    [SerializeField]
    float saveX;
    [SerializeField]
    float saveY;
    [SerializeField]
    float saveZ;
    [Header("ステージを移動するか")]
    [SerializeField]
    bool stagetrg = true;
    [Header("ステージ名")]
    [SerializeField]
    string sceneName = "";
    [Header("フェードイン")]
    [SerializeField]
    GameObject fadeinUI;
    private string PlayerTag = "Player";
    GameObject P = null;
    bool rottrg = false;
    [Header("ステージのサブ名(0=日本語、1=英語)")]
    [SerializeField]
    string[] isvillagename;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        if (offobj != null && GManager.instance.houseTrg == 1)
        {
            offobj.SetActive(false);
            //P.GetComponent<player>().o8removetrg = false;
        }

        if (areaspcol != null && GManager.instance.houseTrg == 1)
        {
            areaspcol.radius = colmax;
        }
        if (bgmas != null && GManager.instance.houseTrg == 1)
        {
            bgmas.Stop();
            bgmas.clip = null;
            bgmas.clip = setbgm;
            bgmas.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider col)
    {
        if(col.tag == PlayerTag && !changetrg && Input.GetKeyDown(KeyCode.E) && entertrg == false)
        {
            if (inputEvent == -1)
            {
                changetrg = true;
                GManager.instance.walktrg = false;
                if (doortrg)
                {
                    if (!rottrg)
                    {
                        rottrg = true;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", -90, "time", 1));
                    }
                    else if (rottrg)
                    {
                        rottrg = false;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", 90, "time", 1));
                    }
                }
                Instantiate(fadeinUI, transform.position, transform.rotation);
                Resources.UnloadUnusedAssets();
                Invoke("SceneChange", 2);
            }
            else if ((inputEvent - 1) < GManager.instance.EventNumber[eventnumber])
            {
                changetrg = true;
                GManager.instance.walktrg = false;
                if (doortrg)
                {
                    if (rottrg!)
                    {
                        rottrg = true;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", -90, "time", 1));
                    }
                    else if (rottrg)
                    {
                        rottrg = false;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", 90, "time", 1));
                    }
                }
                Instantiate(fadeinUI, transform.position, transform.rotation);
                Resources.UnloadUnusedAssets();
                Invoke("SceneChange", 2);
            }
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == PlayerTag && changetrg == false && entertrg == true )//&& col.GetComponent <player >())
        {
            if (inputEvent == -1)
            {
                changetrg = true;
                GManager.instance.walktrg = false;
                if (doortrg)
                {
                    if (!rottrg)
                    {
                        rottrg = true;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", -90, "time", 1));
                    }
                    else if (rottrg)
                    {
                        rottrg = false;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", 90, "time", 1));
                    }
                }
                Instantiate(fadeinUI, transform.position, transform.rotation);
                Resources.UnloadUnusedAssets();
                Invoke("SceneChange", 2);
            }
            else if (inputEvent <= GManager.instance.EventNumber[eventnumber])
            {
                changetrg = true;
                GManager.instance.walktrg = false;
                if (doortrg)
                {
                    if (!rottrg)
                    {
                        rottrg = true;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", -90, "time", 1));
                    }
                    else if (rottrg)
                    {
                        rottrg = false;
                        iTween.RotateAdd(gameObject, iTween.Hash("y", 90, "time", 1));
                    }
                }
                Instantiate(fadeinUI, transform.position, transform.rotation);
                Resources.UnloadUnusedAssets();
                Invoke("SceneChange", 2);
            }
            //else if(ns != null && (inputEvent ) > GManager.instance.EventNumber[eventnumber])
            //{
              //  StartCoroutine(ns.Talk());
           // }
        }
    }
    void SaveDate()
    {
        //後でやる
        PlayerPrefs.SetInt("housetrg", GManager.instance.houseTrg);
        PlayerPrefs.SetInt("dayc", GManager.instance.daycount);
        PlayerPrefs.SetInt("coin", GManager.instance.Coin);
        for (int i = 0; i < GManager.instance.EventNumber.Length;)
        {
            PlayerPrefs.SetInt("EvN" + i, GManager.instance.EventNumber[i]);
            i++;
        }
        for (int i = 0; i < GManager.instance.freenums.Length;)
        {
            PlayerPrefs.SetFloat("freenums" + i, GManager.instance.freenums[i]);
            i++;
        }
        PlayerPrefs.SetFloat("posx", GManager.instance.posX);
        PlayerPrefs.SetFloat("posy", GManager.instance.posY);
        PlayerPrefs.SetFloat("posz", GManager.instance.posZ);
        PlayerPrefs.SetInt("stageN", GManager.instance.stageNumber);
        for (int i = 0; i < GManager.instance.ItemID.Length;)
        {
            PlayerPrefs.SetInt("itemnumber" + i, GManager.instance.ItemID[i].itemnumber);
            PlayerPrefs.SetInt("itemget" + i, GManager.instance.ItemID[i].gettrg);
            PlayerPrefs.SetInt("item_quickset" + i, GManager.instance.ItemID[i]._quickset);
            PlayerPrefs.SetInt("item_equalsset" + i, GManager.instance.ItemID[i]._equalsset);
            PlayerPrefs.SetInt("pl_equalsselect" + i, GManager.instance.ItemID[i].pl_equalsselect);
            i++;
        }
        //---------------
        PlayerPrefs.SetInt("minigame_indexTrg", GManager.instance._minigame.input_indexTrg);
        for (int i = 0; i < GManager.instance._minigame.input_missionID.Length;)
        {
            PlayerPrefs.SetInt("minigame_missionID" + i, GManager.instance._minigame.input_missionID[i]);
            i++;
        }
        GManager.instance._minigame.input_missionID[3] = 7;
        PlayerPrefs.SetString("itemscript46", GManager.instance.ItemID[46].itemscript);

        for (int i = 0; i < GManager.instance.Quick_itemSet.Length;)
        {
            PlayerPrefs.SetInt("quick_itemset" + i, GManager.instance.Quick_itemSet[i]);
            i++;
        }
        for (int i = 0; i < GManager.instance.P_equalsID.Length;)
        {
            PlayerPrefs.SetInt("hand_equals" + i, GManager.instance.P_equalsID[i].hand_equals);
            PlayerPrefs.SetInt("accessory_equals" + i, GManager.instance.P_equalsID[i].accessory_equals);
            i++;
        }
        //---------------
        for (int i = 0; i < GManager.instance.Pstatus.Length;)
        {
            PlayerPrefs.SetInt("pmaxhp" + i, GManager.instance.Pstatus[i].maxHP);
            PlayerPrefs.SetInt("php" + i, GManager.instance.Pstatus[i].hp);
            PlayerPrefs.SetInt("pmaxmp" + i, GManager.instance.Pstatus[i].maxMP);
            PlayerPrefs.SetInt("pmp" + i, GManager.instance.Pstatus[i].mp);
            PlayerPrefs.SetInt("pdf" + i, GManager.instance.Pstatus[i].defense);
            PlayerPrefs.SetInt("pat" + i, GManager.instance.Pstatus[i].attack);
            PlayerPrefs.SetInt("plv" + i, GManager.instance.Pstatus[i].Lv);
            PlayerPrefs.SetInt("pmaxexp" + i, GManager.instance.Pstatus[i].maxExp);
            PlayerPrefs.SetInt("pinputexp" + i, GManager.instance.Pstatus[i].inputExp);
            PlayerPrefs.SetInt("pselectskill" + i, GManager.instance.Pstatus[i].selectskill);
            PlayerPrefs.SetInt("pselectmagic" + i, GManager.instance.Pstatus[i].magicselect);
            for (int j = 0; j < GManager.instance.Pstatus[i].inputskill.Length;)
            {
                PlayerPrefs.SetInt("pinputskill" + i + "" + j, GManager.instance.Pstatus[i].inputskill[j]);
                j++;
            }
            for (int j = 0; j < GManager.instance.Pstatus[i].getMagic.Length;)
            {
                PlayerPrefs.SetInt("pgetmagictrg" + i + "" + j, GManager.instance.Pstatus[i].getMagic[j].gettrg);
                j++;
            }
            for (int j = 0; j < GManager.instance.Pstatus[i].magicSet.Length;)
            {
                PlayerPrefs.SetInt("pmagicset" + i + "" + j, GManager.instance.Pstatus[i].magicSet[j]);
                j++;
            }
            PlayerPrefs.SetInt("getpl" + i, GManager.instance.Pstatus[i].getpl);
            i++;
        }
        PlayerPrefs.SetInt("plselect", GManager.instance.playerselect);
        for (int i = 0; i < GManager.instance.Triggers.Length;)
        {
            PlayerPrefs.SetInt("gmtrg" + i, GManager.instance.Triggers[i]);
            i++;
        }
        for (int i = 0; i < GManager.instance.missionID.Length;)
        {
            PlayerPrefs.SetInt("inputmission" + i, GManager.instance.missionID[i].inputmission);
            i++;
        }
        for (int i = 0; i < GManager.instance.achievementsID.Length;)
        {
            PlayerPrefs.SetInt("achiget" + i, GManager.instance.achievementsID[i].gettrg);
            i++;
        }
        for (int i = 0; i < GManager.instance.enemynoteID.Length;)
        {
            PlayerPrefs.SetInt("enemynoteget" + i, GManager.instance.enemynoteID[i].gettrg);
            i++;
        }
        PlayerPrefs.SetFloat("audioMax", GManager.instance.audioMax);
        PlayerPrefs.SetInt("Mode", GManager.instance.mode);
        PlayerPrefs.SetInt("isEn", GManager.instance.isEnglish);
        PlayerPrefs.SetInt("Reduction", GManager.instance.reduction);
        PlayerPrefs.SetFloat("suntime", GManager.instance.sunTime);
        //PlayerPrefs.SetInt("viewUp", GManager.instance.autoviewup);
        PlayerPrefs.SetInt("longDash", GManager.instance.autolongdash);
        PlayerPrefs.SetInt("autoattack", GManager.instance.autoattack);
        PlayerPrefs.SetFloat("rotpivot", GManager.instance.rotpivot);
        for (int i = 0; i < GManager.instance.mobDsTrg.Length;)
        {
            PlayerPrefs.SetInt("mdt" + i, GManager.instance.mobDsTrg[i]);
            i++;
        }
        PlayerPrefs.Save();
    }
    void SceneChange()
    {
        if (P != null)
        {
            if(outeventid != -1 && GManager.instance.EventNumber[outeventid] == outeventinput)
            {
                GManager.instance.EventNumber[outeventid] = outeventinput + 1;
            }
            if (isvillagename != null && isvillagename.Length > 0 && GManager.instance.isEnglish == 0)
            {
                GManager.instance.villageName = isvillagename[0];
            }
            else if (isvillagename != null && isvillagename.Length > 0 && GManager.instance.isEnglish == 1)
            {
                GManager.instance.villageName = isvillagename[1];
            }
            else
            {
                GManager.instance.villageName = "";
            }
            GManager.instance.houseTrg = houseSet;

            if (addtrg == true)
            {
                addtrg = false;
                GManager.instance.stageNumber += number;
            }
            if (removetrg == true)
            {
                removetrg = false;
                GManager.instance.stageNumber -= number;
            }
            PlayerPrefs.SetInt("stageNumber", GManager.instance.stageNumber);
           
            GManager.instance.posX = saveX;
            PlayerPrefs.SetFloat("posX", GManager.instance.posX);
            GManager.instance.posY = saveY;
            PlayerPrefs.SetFloat("posY", GManager.instance.posY);
            GManager.instance.posZ = saveZ;
            PlayerPrefs.SetFloat("posZ", GManager.instance.posZ);
            PlayerPrefs.Save();
            SaveDate();
            GManager.instance.walktrg = true;
            if (offobj != null)
            {
                offobj.SetActive(false);
            }
            else if (offobj == null)
            {
            }
            if (onobj != null)
            {
                onobj.SetActive(true);
            }
            if (areaspcol != null)
            {
                areaspcol.radius = colmax;
            }
            else if (areaspcol == null)
            {

            }

            if (bgmas != null)
            {
                bgmas.Stop();
                bgmas.clip = null;
                bgmas.clip = setbgm;
                bgmas.Play();

            }
            else if (bgmas == null)
            {
            }
            if (onese != null && this.GetComponent<AudioSource>())
            {
                this.GetComponent<AudioSource>().PlayOneShot(onese);
            }
            if (sceneName == "")
            {
                changetrg = false;
                var tppos = P.transform.position;
                tppos.x = saveX;
                tppos.y = saveY;
                tppos.z = saveZ;
                P.transform.position = tppos;
            }
            else if (stagetrg == false)
            {
                SceneManager.LoadScene(sceneName);
            }
            else if (stagetrg == true)
            {
                SceneManager.LoadScene(sceneName + GManager.instance.stageNumber);
            }
        }
    }
}
