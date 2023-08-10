using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public Player _players;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if(_instance == null)
                {
                    GameObject manager = new GameObject("GameManager");
                    _instance = manager.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    [SerializeField]
    private PoolManager _pool;
    public PoolManager Pool
    { get { return _pool; } }

    private GameObject _player;
    public GameObject Player
    {
        get { return _player; }
    }

    [SerializeField]
    private float _gameTime = 0.0f;
    public float GameTime
    {
        get { return _gameTime; }
    }

    [SerializeField]
    private TMP_Text _gameTimeText;

    [SerializeField]
    private TMP_Text _deadMonsterText;

    private LevelSystem _levelSystem = null;

    [SerializeField]
    private Image _expBar;

    private int _numberOfDeadMonster = 0;

    public int NumberOfDeadMonster
    {
        get { return _numberOfDeadMonster; }
        set { _numberOfDeadMonster = value; }
    }

    private void Awake()
    {
        _instance = this;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        _numberOfDeadMonster = 0;
        Vector3 pos = _gameTimeText.GetComponent<RectTransform>().anchoredPosition;
        pos.y = -100;
        pos.x = 0;
        _gameTimeText.GetComponent<RectTransform>().anchoredPosition = pos;

        pos = _deadMonsterText.GetComponent<RectTransform>().anchoredPosition;
        pos.x = -186;
        pos.y = -114;
        _deadMonsterText.GetComponent<RectTransform>().anchoredPosition = pos;

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            _gameTime = 0.0f;
            _levelSystem = _player.GetComponent<LevelSystem>();
            _expBar.fillAmount = 0.0f;
        }
    }

    private IEnumerator GameOverScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("GameOverScene");
    }

    private IEnumerator GameClearScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("GameClearScene");
    }

    private void Update()
    {
        float playerHp = _player.GetComponent<HealthPoint>().HP;

        if(playerHp <= 0)
        {
            StartCoroutine(GameOverScene(3f));
        }

        if(_gameTime >= 600f)
        {
            StartCoroutine(GameClearScene(3f));
        }


        // 현재 Scene의 이름이 MainScene이면 Update 함수를 실행합니다.
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            // Update 함수 내용을 여기에 작성합니다.
            ShowTime();
            UpdateExpBar();
            ShowNumberOfDeadMonsters();
        }
    }

    private void ShowTime()
    {
        _gameTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(_gameTime / 60f);
        int seconds = Mathf.FloorToInt(_gameTime % 60f);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

        _gameTimeText.text = timeText;
    }

    private void ShowNumberOfDeadMonsters()
    {
        string deadMonsterText = _numberOfDeadMonster + "";
        _deadMonsterText.text = deadMonsterText;
    }

    private void UpdateExpBar()
    {
        float maxExpValue = _levelSystem.MaxExp;
        float expValue = _levelSystem.Exp;

        float fillAmountValue = expValue / maxExpValue;

        _expBar.fillAmount = fillAmountValue;
    }
}
