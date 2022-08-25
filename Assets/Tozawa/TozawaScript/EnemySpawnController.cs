using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ステージの自動生成を管理するコンポーネント（スクリプト）
/// </summary>
public class EnemySpawnController : MonoBehaviour
{
    [Header("出てきてほしい敵のプレハブを入れてください"), Tooltip("生成するプレハブの配列"), SerializeField]
    GameObject[] _stagePrefab = new GameObject[0];
    [Header("Tekiが生まれる場所をドラッグアンドドロップしてね"), Tooltip("スポーン場所のトランスフォーム"), SerializeField]
    Transform _spawnPoint = default;
    [Header("敵が生成される間隔を調整してね"), Tooltip("スポーンインターバル"), SerializeField]
    float _spawnInterval = 0;
    int _random = default;
    float _time = 0;
    private void Update()
    {
        StageSpawner();//ステージの自動生成を行う関数
    }
    void StageSpawner()
    {
        _time += Time.deltaTime;
        if (_time > _spawnInterval)
        {
            _random = Random.Range(0, _stagePrefab.Length);
            Instantiate(_stagePrefab[_random], _spawnPoint.position, Quaternion.Euler(0,-90,0));
            _time = 0;
        }
    }
}
