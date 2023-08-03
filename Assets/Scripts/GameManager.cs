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

    private float _gameTime = 0.0f;

    [SerializeField]
    private TMP_Text _gameTimeText;

    private LevelSystem _levelSystem = null;

    [SerializeField]
    private Image _expBar;

    private void Awake()
    {
        _instance = this;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        Vector3 pos = _gameTimeText.GetComponent<RectTransform>().anchoredPosition;
        pos.y = -100;
        _gameTimeText.GetComponent<RectTransform>().anchoredPosition = pos;

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

        GameObject BossMonster = GameObject.FindGameObjectWithTag("Boss");
        if(BossMonster != null)
        {
            float bossHp = BossMonster.GetComponent<HealthPoint>().HP;

            if(bossHp <= 0) 
            {
                StartCoroutine(GameClearScene(3f));
            }
        }


        // 현재 Scene의 이름이 MainScene이면 Update 함수를 실행합니다.
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            // Update 함수 내용을 여기에 작성합니다.
            ShowTime();
            UpdateExpBar();
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

    private void UpdateExpBar()
    {
        float maxExpValue = _levelSystem.MaxExp;
        float expValue = _levelSystem.Exp;

        float fillAmountValue = expValue / maxExpValue;

        _expBar.fillAmount = fillAmountValue;
    }
}
