using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �X�e�[�W�̎����������Ǘ�����R���|�[�l���g�i�X�N���v�g�j
/// </summary>
public class EnemySpawnController : MonoBehaviour
{
    [Header("�o�Ă��Ăق����G�̃v���n�u�����Ă�������"), Tooltip("��������v���n�u�̔z��"), SerializeField]
    GameObject[] _stagePrefab = new GameObject[0];
    [Header("Teki�����܂��ꏊ���h���b�O�A���h�h���b�v���Ă�"), Tooltip("�X�|�[���ꏊ�̃g�����X�t�H�[��"), SerializeField]
    Transform _spawnPoint = default;
    [Header("�G�����������Ԋu�𒲐����Ă�"), Tooltip("�X�|�[���C���^�[�o��"), SerializeField]
    float _spawnInterval = 0;
    int _random = default;
    float _time = 0;
    private void Update()
    {
        StageSpawner();//�X�e�[�W�̎����������s���֐�
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
