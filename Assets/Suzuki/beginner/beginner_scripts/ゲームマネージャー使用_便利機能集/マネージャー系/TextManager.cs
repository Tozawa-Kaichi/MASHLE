﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour
{
    private int oldis = 0;

    [Header("[テキストマネージャー]\n英語文")]
    [Multiline]
    [SerializeField]
    string englishText;

    [Multiline]
    string jpText;

    int jpFontSize;

    [Header("英語時のフォントサイズ")]
    [SerializeField]
    int englishFontSize;

    [Header("絶対に英語文を表示するかどうか")]
    [SerializeField]
    bool nosetTrg = false;
    void Start()
    {
        
        Text text = GetComponent<Text>();
        jpText = text.text;
        jpFontSize = text.fontSize;
        if (GManager.instance.isEnglish == 1)
        {
            text.text = englishText;
            if (englishFontSize != 0)
            {
                text.fontSize = englishFontSize;
            }
            if(nosetTrg)
            {
                this.gameObject.SetActive(false);
            }
        }
        oldis = GManager.instance.isEnglish;
    }
    void Update()
    {
        if(oldis != GManager.instance.isEnglish )
        {
            Text text = GetComponent<Text>();
            if (GManager.instance.isEnglish == 1)
            {
                text.text = englishText;
                if (englishFontSize != 0)
                {
                    text.fontSize = englishFontSize;
                }
                if (nosetTrg)
                {
                    this.gameObject.SetActive(false);
                }
            }
            else if (GManager.instance.isEnglish == 0)
            {
                text.text = jpText;
                if (englishFontSize != jpFontSize)
                {
                    text.fontSize = jpFontSize;
                }
                if (nosetTrg)
                {
                    this.gameObject.SetActive(true);
                }
            }
            oldis = GManager.instance.isEnglish;
        }
    }
}
