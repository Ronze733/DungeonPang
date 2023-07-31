using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : UIManager
{
    [SerializeField]
    private GameObject _inGameMenu = null;

    [SerializeField]
    private TextMeshProUGUI _exitButtonText;
    [SerializeField]
    private TextMeshProUGUI _resumeButtonText;
    [SerializeField]
    private TextMeshProUGUI _pointText;

    [SerializeField]
    private GameObject _levelup = null;

    // Start is called before the first frame update
    private void Start()
    {
        _inGameMenu.SetActive(false);
        _exitButtonText.text = "Exit";
        _resumeButtonText.text = "Resume";
    }

    // Update is called once per frame
    private void Update()
    {
        bool isLevelUp = _levelup.activeSelf;

        if (Input.GetKeyUp(KeyCode.Escape) && !isLevelUp)
        {
            if(_inGameMenu.activeSelf)
                ResumeGame();
            else
            {
                _inGameMenu.SetActive(true);
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        if (!_inGameMenu.activeSelf) return;

        if (!_isPaused)
        {
            _isPaused = true;
            Time.timeScale = 0.0f;
            float point = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>().Coin;
            int intPoint = Mathf.FloorToInt(point);
            _pointText.text = "Score : " + intPoint;
            _pointText.fontSize = 60.0f;
            _pointText.enableWordWrapping = false;
        }
    }

    public void ResumeGame()
    {
        if (!_inGameMenu.activeSelf) return;

        if (_isPaused)
        {
            Time.timeScale = 1f;
            _isPaused = false;
            if (_inGameMenu.activeSelf)
                _inGameMenu.SetActive(false);
        }
    }

    public void ChangeScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
