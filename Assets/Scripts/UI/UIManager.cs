using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get { return _instance; }
    }

    protected bool _isPaused = false;

    public bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; }
    }
}
