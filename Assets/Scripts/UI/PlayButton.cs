using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void Start()
    {
        ChangeButtonText();
    }

    private void ChangeButtonText()
    {
        TMP_Text tmpText = GetComponentInChildren<TMP_Text>();
        if (tmpText != null)
            tmpText.text = "Play";
        else
            Debug.LogWarning("Tmp_text component not found as a child of the button");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
