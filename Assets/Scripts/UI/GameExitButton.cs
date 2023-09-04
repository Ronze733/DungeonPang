using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitButton : ButtonController
{
    // Start is called before the first frame update
    private void Start()
    {
        ChangeButtonText("GameExit");
        RectTransform buttonRect = this.GetComponent<RectTransform>();

        Vector3 newPosition = new Vector3(0f, -350f, 0f);
        buttonRect.localPosition = newPosition;

        buttonRect.pivot = new Vector2(0.5f, 0.5f);
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
