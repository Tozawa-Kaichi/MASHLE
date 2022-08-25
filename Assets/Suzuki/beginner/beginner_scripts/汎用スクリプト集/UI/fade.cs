
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class fade : MonoBehaviour
{
    [Header("フェードイン、アウトを1つで")]
    Image imagecolor;
    
    [Header("フェードタイム")]
    [SerializeField]
    float FadeOutTime = 0f;
    
    [Header("フェード後のステージ")]
    [SerializeField]
    string NextScene;

    [Header("フェードモード(0は両方、1はインだけ、-1はアウトだけ)")]
    [SerializeField]
    int fademode = 0;

    private float alphacolor = 1.0f;
    
    void Start()
    {
        imagecolor = this.GetComponent<Image>();
    }

    void Update()
    {
        
        FadeOutTime += Time.deltaTime;
        if(FadeOutTime >0f && fademode==-1)
        {
            alphacolor = FadeOutTime;
            imagecolor.color = new Color(1.0f, 1.0f, 1.0f, alphacolor);
            imagecolor = this.GetComponent<Image>();
        }
        else if((fademode==0 || fademode==1) && FadeOutTime < 1)
        {
             alphacolor = FadeOutTime;
            imagecolor.color = new Color(1.0f, 1.0f, 1.0f, alphacolor);
            imagecolor = this.GetComponent<Image>();
        }
        else if(FadeOutTime >= 1)
        {
            fademode = -1;
            if (NextScene != "")
            {
                SceneManager.LoadScene(NextScene);
            }
        }

        
    }






}
