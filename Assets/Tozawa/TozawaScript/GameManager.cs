using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] Text timerText;
    [Header("§ŒÀŠÔ‚ğ’²®‚µ‚Ä‚Ë"), Tooltip("§ŒÀŠÔ"), SerializeField]
    float _timeLimit = 0;
    float _timer = 0;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        TimerCount();
    }
    void TimerCount()
    {
        _timer += Time.deltaTime;
        _timeLimit -= _timer;
    }
}
