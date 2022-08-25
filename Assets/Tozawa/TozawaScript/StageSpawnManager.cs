using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ステージの自動生成を管理するコンポーネント（スクリプト）
/// </summary>
public class StageSpawnManager : MonoBehaviour
{
    [Header("出てきてほしいステージのプレハブを入れてください"), Tooltip("生成するプレハブの配列"), SerializeField]
    GameObject[] _stagePrefab = new GameObject[0];
    [Header("ステージが生まれる場所をドラッグアンドドロップしてね"), Tooltip("スポーン場所のトランスフォーム"), SerializeField]
    Transform _spawnPoint = default;
    [Header("ステージが生成される間隔を調整してね"), Tooltip("スポーンインターバル"), SerializeField]
    float _spawnInterval = 0;
    int _random = default;
    float _time = 0;
    //----------------------------------------------------------------
    [SerializeField] float ULTRA_SPEED = 0.7f;
    private void Update()
    {
        if(PlayerDashAnimController.urtraDash)
        {
            _spawnInterval = ULTRA_SPEED;
        }
        StageSpawner();//ステージの自動生成を行う関数
    }
    void StageSpawner()
    {
        _time += Time.deltaTime;
        if (_time > _spawnInterval)
        {
            _random = Random.Range(0,_stagePrefab.Length);
            Instantiate(_stagePrefab[_random],_spawnPoint.position,Quaternion.identity);
            _time = 0;
        }
    }
}
