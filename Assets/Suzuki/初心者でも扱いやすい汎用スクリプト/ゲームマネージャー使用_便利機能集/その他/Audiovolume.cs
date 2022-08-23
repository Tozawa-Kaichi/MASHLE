using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiovolume : MonoBehaviour
{
    [Header("[音量調整などで使う]\n戦闘時でも音を流すか")]
    [SerializeField]
    bool battletrg = false;
    private bool isadd = false;
    float oldvolume;
    [Header("効果音の音なのかどうか")]
    [SerializeField]
    bool setrg = false;
    void Start()
    {
        //アタッチされているAudioSource取得
        AudioSource audio = GetComponent<AudioSource>();
        if(GManager.instance.over)
        {
            audio.volume = GManager.instance.audioMax / 12;
            oldvolume = GManager.instance.audioMax / 12;
        }
        else if (!setrg)
        {
            audio.volume = GManager.instance.audioMax / 4;
            oldvolume = GManager.instance.audioMax / 4;
        }
        else if (setrg)
        {
            audio.volume = GManager.instance.audioMax  ;
            oldvolume = GManager.instance.audioMax ;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (GManager.instance.over || !GManager.instance.walktrg )
        {
            if (oldvolume != GManager.instance.audioMax / 16 && !setrg && !GManager.instance.over )
            {
                audio.volume = GManager.instance.audioMax / 16;
                oldvolume = GManager.instance.audioMax / 16;
            }
            else if (oldvolume != 0 && !setrg && GManager.instance.over)
            {
                audio.volume = 0;
                oldvolume = 0;
            }
        }
        else if (!setrg && oldvolume != GManager.instance.audioMax / 4)
        {
            audio.volume = GManager.instance.audioMax / 4;
            oldvolume = GManager.instance.audioMax / 4;
        }
        else if (setrg && oldvolume != GManager.instance.audioMax)
        {
            audio.volume = GManager.instance.audioMax;
            oldvolume = GManager.instance.audioMax;
        }
        //オンオフ
        if (!battletrg && !GManager.instance.walktrg && !isadd)
        {
            audio.enabled = false;
            isadd = true;
        }
        else if (!battletrg && GManager.instance.walktrg && isadd)
        {
            audio.enabled = true;
            isadd = false;
        }
    }
}
