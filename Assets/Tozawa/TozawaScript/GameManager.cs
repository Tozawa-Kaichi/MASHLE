using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEngine.Events.UnityEvent _onGameOver;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameClear;
    [SerializeField] Text _timerText;
    [SerializeField] GameObject _player;
    [Header("§ŒÀŠÔ‚ğ’²®‚µ‚Ä‚Ë"), Tooltip("§ŒÀŠÔ"), SerializeField]
    float _timeLimit = 0;
    float _limit;
    int _timer = 0;
    bool _gameisStarted = false;
    private void Start()
    {
        _limit = _timeLimit;
        _gameisStarted = false;
    }
    private void Update()
    {
        if(_gameisStarted&&_player)
        {
            if (_player.transform.position.y <= -10)
            {
                GameOver();
            }
        }
        if(_timeLimit <= 0)
        {
            GameClear();
        }
        
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
        Invoke(nameof(LoadScene) ,5f);
    }
    public void GameClear()
    {
        _onGameClear.Invoke();
        Invoke(nameof(LoadScene), 5f);
    }
    public void GameStart()
    {
        _onGameStart.Invoke();
        _gameisStarted = true;
    }
    void LoadScene()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
