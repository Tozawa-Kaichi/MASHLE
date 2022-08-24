using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// Playerの走る動作アニメーションを管理するコンポーネント
/// </summary>
public class PlayerDashAnimController : MonoBehaviour
{
    Animator _anim = default;
    int combo = 0;
    float _animSpeedParam = 1;
    PlayerState _playerState = default;
    [SerializeField] bool _getItem = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        SpeedControle();
        if(_getItem == true)
        {
            _playerState = PlayerState.UltraDash;
        }
        else
        {
            _playerState = PlayerState.NormalDash;
        }
        if(combo > 5)
        {
            _getItem = true;
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
        combo += 1;
        _ccImpulse.GenerateImpulse();
    }
}
