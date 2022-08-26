using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class JumpController : MonoBehaviour
{
    /// <summary>ジャンプする時に使うパラメーター</summary>
    [SerializeField] float _jumpParameter = 3f;
    /// <summary>最大ジャンプ回数</summary>
    [SerializeField] int _maxJumpCount = 2;
    [HeaderAttribute("Grounded Area")]
    /// <summary>接地判定範囲の中心点（オフセット）</summary>
    [SerializeField] Vector3 _center = default;
    /// <summary>接地判定範囲の半径</summary>
    [SerializeField] float _radius = 1f;
    /// <summary>地面と判定するレイヤー</summary>
    [SerializeField, Tooltip("地面と判定するレイヤー")] LayerMask _groundLayer = ~0;
    /// <summary>ジャンプしている回数</summary>
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
        // 垂直方向の速度を保持しながら、入力した方向へ動かす
        float verticalVelocity = _rb.velocity.y;
        _rb.velocity = _dir.normalized + Vector3.up * verticalVelocity;

        // ジャンプ処理
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
