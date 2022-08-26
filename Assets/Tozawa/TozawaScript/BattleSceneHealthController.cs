using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BattleSceneHealthController : MonoBehaviour
{
    [SerializeField] int _bossHealth;
    [SerializeField] int _playerHealth;
    [SerializeField] int _powerOfSpecialGage;
    [SerializeField] int _bossAttackDamage;
    [SerializeField] float _bossAttackInterval;

    [SerializeField] int _normalDamegeNum;
    [SerializeField] GameObject _damagePrefabOfNormalAttack;

    [SerializeField] int _middleDamegeNum;
    [SerializeField] GameObject _damagePrefabOfMiddleAttack;

    [SerializeField] int _specialDamegeNum;
    [SerializeField] GameObject _damagePrefabOfSpecialAttack;

    [SerializeField] GameObject _playerGameObject;
    [SerializeField] GameObject _bossGameObject;

    [SerializeField] GameObject _specialAttackQTEPrefab;

    [SerializeField] Text _bossHptext;
    [SerializeField] Text _playerHptext;
    [SerializeField] Slider _bossSlider;
    [SerializeField] Slider _playerSlider;
    [SerializeField] Slider _SpecialGageSlider;

    [SerializeField] UnityEngine.Events.UnityEvent _onGameOver;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameClear;

    float _bossAttackTime = 0;
    Animator _bossAnim = default;
    Animator _playerAnim = default;

    //----------------------------
    const int SPECIAL_MAX = 100;
    // Start is called before the first frame update
    void Start()
    {
        _bossAnim = _bossGameObject.GetComponent<Animator>();
        _playerAnim = _playerGameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_bossGameObject)
        {
            BossAttack();
        }
        
        HpPreView();
        SliderView();
        DeathCheck();
        AddSpecialGage();
    }
    void HpPreView()
    {
        _playerHptext.text = _playerHealth.ToString();
        _bossHptext.text = _bossHealth.ToString();
    }
    void SliderView()
    {
        _bossSlider.value = _bossHealth;
        _playerSlider.value = _playerHealth;
        _SpecialGageSlider.value = _powerOfSpecialGage;
    }
    void AddSpecialGage()
    {
        _powerOfSpecialGage += 1 ;
        if(_powerOfSpecialGage >= SPECIAL_MAX)
        {
            _powerOfSpecialGage = SPECIAL_MAX;
        }
    }
    void BossAttack()
    {
        _bossAttackTime += Time.deltaTime;
        if(_bossAttackTime >= _bossAttackInterval)
        {
            _bossAnim.SetTrigger("BossAttack");
            _playerHealth -= _bossAttackDamage;
            _bossAttackTime = 0;
        }
    }

    void DeathCheck()
    {
        if(0 >= _bossHealth)
        {
            _bossHealth = 0;
            Destroy(_bossGameObject);
            _onGameClear.Invoke();
            Invoke(nameof(LoadScene), 5f);
        }
        if (0 >= _playerHealth)
        {
            _playerHealth = 0;
            Destroy(_playerGameObject);
            _onGameOver.Invoke();
            Invoke(nameof(LoadScene), 5f);
        }
    }


    public void PlayerNormalAttack()
    {
        _bossHealth -= _normalDamegeNum;
        Instantiate(_damagePrefabOfNormalAttack,_bossGameObject.transform);
    }
    public void PlayerMiddleAttack()
    {
        _bossHealth -= _middleDamegeNum;
        Instantiate(_damagePrefabOfMiddleAttack, _bossGameObject.transform);
    }
    public void PlayerSpecialAttack()
    {
        if(_powerOfSpecialGage == SPECIAL_MAX)
        {
            _bossHealth -= _specialDamegeNum;
            Instantiate(_specialAttackQTEPrefab);
            _powerOfSpecialGage = 0;
        }
    }
        
    void LoadScene()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
