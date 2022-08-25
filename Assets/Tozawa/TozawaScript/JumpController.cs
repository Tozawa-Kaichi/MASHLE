using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class JumpController : MonoBehaviour
{
    /// <summary>�W�����v���鎞�Ɏg���p�����[�^�[</summary>
    [SerializeField] float _jumpParameter = 3f;
    /// <summary>�ő�W�����v��</summary>
    [SerializeField] int _maxJumpCount = 2;
    [HeaderAttribute("Grounded Area")]
    /// <summary>�ڒn����͈͂̒��S�_�i�I�t�Z�b�g�j</summary>
    [SerializeField] Vector3 _center = default;
    /// <summary>�ڒn����͈͂̔��a</summary>
    [SerializeField] float _radius = 1f;
    /// <summary>�n�ʂƔ��肷�郌�C���[</summary>
    [SerializeField, Tooltip("�n�ʂƔ��肷�郌�C���[")] LayerMask _groundLayer = ~0;
    /// <summary>�W�����v���Ă����</summary>
    int _jumpCount = 0;
    Rigidbody _rb = default;
    Vector3 _dir = default;
    Animator _anim = default;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _dir = new Vector3(0, 0, 0);
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;
        // ���������̑��x��ێ����Ȃ���A���͂��������֓�����
        float verticalVelocity = _rb.velocity.y;
        _rb.velocity = _dir.normalized + Vector3.up * verticalVelocity;

        // �W�����v����
        if (Input.GetButtonDown("Jump") && (IsGrounded() || _jumpCount < _maxJumpCount))
        {
            _jumpCount++;
            _anim.SetTrigger("isJump");
            _rb.AddForce(Vector3.up * _jumpParameter, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        IsGrounded();
    }
    
    Vector3 GetGroundedAreaCenter()
    {
        return this.transform.position + _center;
    }
    bool IsGrounded()
    {
        if (Physics.OverlapSphere(GetGroundedAreaCenter(), _radius, _groundLayer).Length > 0)
        {
            _jumpCount = 0;
            return true;
        }

        return false;
    }
}
