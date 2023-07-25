using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _inGameMenu = null;

    private bool _isPaused = false;
    public bool IsPaused
    { get { return _isPaused; } }

    [SerializeField]
    private TextMeshProUGUI _exitButtonText;
    [SerializeField]
    private TextMeshProUGUI _resumeButtonText;

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
        if (Input.GetKeyUp(KeyCode.Escape))
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
