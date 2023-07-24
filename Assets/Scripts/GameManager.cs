using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField]
    private PoolManager _pool;
    public PoolManager Pool
    { get { return _pool; } }

    private GameObject _player;
    // public Player _player;

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
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            _gameTime = 0.0f;
            _levelSystem = _player.GetComponent<LevelSystem>();
            _expBar.fillAmount = 0.0f;
        }
    }

    private void Update()
    {
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
