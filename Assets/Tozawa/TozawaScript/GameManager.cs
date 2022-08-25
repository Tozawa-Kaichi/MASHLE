using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEngine.Events.UnityEvent _onGameOver;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameClear;
    [SerializeField] Text _timerText;
    [Header("êßå¿éûä‘Çí≤êÆÇµÇƒÇÀ"), Tooltip("êßå¿éûä‘"), SerializeField]
    float _timeLimit = 0;
    float _limit;
    int _timer = 0;
    private void Start()
    {
        _limit = _timeLimit;
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        TimerCount();
        TimeLimitisHalf();
    }
    void TimerCount()
    {
        _timeLimit -= Time.deltaTime;
        _timer = (int)_timeLimit;
        _timerText.text = _timer.ToString();
    }
    void TimeLimitisHalf()
    {
        if(_timeLimit < _limit/2)
        {
            PlayerDashAnimController.urtraDash = true;
        }
    }
    public void GameOver()
    {
        _onGameOver.Invoke();
    }
    public void GameClear()
    {
        _onGameClear.Invoke();
    }
    public void GameStart()
    {
        _onGameStart.Invoke();
    }
}
