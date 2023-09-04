using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitButton : ButtonController
{
    // Start is called before the first frame update
    private void Start()
    {
        ChangeButtonText("GameExit");
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
