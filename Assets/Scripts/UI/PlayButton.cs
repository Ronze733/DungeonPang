using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : ButtonController
{
    private void Start()
    {
        ChangeButtonText("Play");
    }
}
