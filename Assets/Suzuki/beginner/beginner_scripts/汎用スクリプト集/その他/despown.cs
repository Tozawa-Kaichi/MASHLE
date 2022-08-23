using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despown : MonoBehaviour
{
    [Header("[オブジェクトを消すやつ]\n出現してから消すまでの時間")]
    [SerializeField]
    float time = 0f;
    [Header("消す時エフェクトを出すか")]
    [SerializeField]
    bool effecttrg = true;
    [Header("エフェクトを指定")]
    [SerializeField]
    int effectindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Tds", time);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Tds()
    {
        if (effecttrg)
        {
            Instantiate(GManager.instance.effectobj[effectindex], this.transform.position, this.transform.rotation);
        }
        Destroy(this.gameObject, 0.1f);

    }
}
