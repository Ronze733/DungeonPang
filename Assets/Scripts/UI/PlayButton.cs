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
        RectTransform buttonRect = this.GetComponent<RectTransform>();

        Vector3 newPosition = new Vector3(0f, -240f, 0f);
        buttonRect.localPosition = newPosition;

        buttonRect.pivot = new Vector2(0.5f, 0.5f);
    }
}
