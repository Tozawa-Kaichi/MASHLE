using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// Playerの走る動作アニメーションを管理するコンポーネント
/// </summary>
public class PlayerDashAnimController : MonoBehaviour
{
    public static bool urtraDash = false;
    Animator _anim = default;
    float _animSpeedParam = 1;
    PlayerState _playerState = default;
    [SerializeField] Transform _deathLineofY;
    CinemachineImpulseSource _ccImpulse;
    //-----------------------------------------
    const float NOMAL_SPEED = 3;
    const float ULTRA_SPEED = 5;
    // Start is called before the first frame update
    void Start()
    {
        _ccImpulse = GetComponent<CinemachineImpulseSource>();
        _anim = GetComponent<Animator>();
        _playerState = PlayerState.Non;
        urtraDash = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedControle();
        if(urtraDash == true)
        {
            _playerState = PlayerState.UltraDash;
        }
        else
        {
            _playerState = PlayerState.NormalDash;
        }

        
    }
    void LateUpdate()
    {
        _anim.SetFloat("Speed", _animSpeedParam);
    }
    void SpeedControle()
    {
        if(_playerState == PlayerState.NormalDash)
        {
            _animSpeedParam += 0.1f;
            if(_animSpeedParam >= NOMAL_SPEED)
            {
                _animSpeedParam = NOMAL_SPEED;
            }

        }
        else if(_playerState == PlayerState.UltraDash)
        {
            _animSpeedParam += 0.1f;
            if (_animSpeedParam >= ULTRA_SPEED)
            {
                _animSpeedParam = ULTRA_SPEED;
            }
        }
    }
    public void GetStart()
    {
        _playerState = PlayerState.NormalDash;
        _anim.SetTrigger("Start");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _ccImpulse.GenerateImpulse();
            _anim.SetTrigger("Attack");
        }
    }
}
