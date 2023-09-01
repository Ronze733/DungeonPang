using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    protected void ChangeButtonText(string str)
    {
        TMP_Text tmpText = GetComponentInChildren<TMP_Text>();
        if (tmpText != null)
            tmpText.text = str;
        else
            Debug.LogWarning("Tmp_text component not found as a child of the button");
    }

    [SerializeField]
    protected string _str;
    public void LoadGameScene()
    {
        string str = _str;
        SceneManager.LoadScene(str);
    }
}
