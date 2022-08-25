using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 生成されたステージの動作を管理するスクリプト
/// 横に流れる水のように
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class StageController : MonoBehaviour
{
    [Header("この部分を過ぎたら消滅するというX座標の値を調節してください"), Tooltip("ステージが消滅する座標"), SerializeField]
    int _deathLineBorderofHorizon = 0;
    [Header("ステージの移動速度を調整してください"), Tooltip("ステージの移動速度"), SerializeField]
    float _stageSpeed =3;
    Rigidbody _rb;//リジッドボディ格納変数

    //----------------------------------------------------------------
    const int NEGATIVE_NUM = -1;
    const int NORMAL_SPEED = 3;
    [SerializeField] const int ULTRA_SPEED = 6;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody取得
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOverTheLine();
        //移動を行う関数
        StageMove();
        if(PlayerDashAnimController.urtraDash)
        {
            _stageSpeed = ULTRA_SPEED;
        }
        else
        {
            _stageSpeed = NORMAL_SPEED;
        }
    }
    public void DestroyOverTheLine()
    {
        //決められたラインを超えたら消滅
        if (this.transform.position.x < _deathLineBorderofHorizon)
        {
            Destroy(this.gameObject);
        }
    }
    public void StageMove()
    {
        _rb.velocity = new Vector3(_stageSpeed * NEGATIVE_NUM,0);
    }
}
