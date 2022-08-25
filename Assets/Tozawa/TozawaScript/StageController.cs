using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������ꂽ�X�e�[�W�̓�����Ǘ�����X�N���v�g
/// ���ɗ���鐅�̂悤��
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class StageController : MonoBehaviour
{
    [Header("���̕������߂�������ł���Ƃ���X���W�̒l�𒲐߂��Ă�������"), Tooltip("�X�e�[�W�����ł�����W"), SerializeField]
    int _deathLineBorderofHorizon = 0;
    [Header("�X�e�[�W�̈ړ����x�𒲐����Ă�������"), Tooltip("�X�e�[�W�̈ړ����x"), SerializeField]
    float _stageSpeed =3;
    Rigidbody _rb;//���W�b�h�{�f�B�i�[�ϐ�

    //----------------------------------------------------------------
    const int NEGATIVE_NUM = -1;
    const int NORMAL_SPEED = 3;
    [SerializeField] const int ULTRA_SPEED = 6;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody�擾
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOverTheLine();
        //�ړ����s���֐�
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
        //���߂�ꂽ���C���𒴂��������
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
