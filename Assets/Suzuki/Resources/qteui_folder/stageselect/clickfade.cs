using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class clickfade : MonoBehaviour
{
    [Header("フェードUIをセット"),SerializeField]
    GameObject fadein;
    [Header("UIのaudiosourceをセット※必須ではない"), SerializeField]
    AudioSource audioS = null;
    [Header("効果音をセット※必須ではない"), SerializeField]
    AudioClip se = null;
    [Header("ステージ指定※ボタンそれぞれに"), SerializeField]
    int stage_number = 1;
    [Header("UIのアニメーションをセット"), SerializeField]
    Animator ui_anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    public void highlightCommand()
    {
        ui_anim.SetInteger("Anumber", 1);
    }
    public void normalCommand()
    {
        ui_anim.SetInteger("Anumber", 0);
    }
    public void clickCommand()
    {
        audioS.PlayOneShot(se);
        Instantiate(fadein, transform.position, transform.rotation);
        Invoke("MoveScene", 1);
    }
    void MoveScene()
    {
        SceneManager.LoadScene("RunGameStage0" + stage_number);
    }
   
}
