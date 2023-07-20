using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public PoolManager _pool;
    public Player _player;
    // public Player _player;

    void Awake()
    {
        _instance = this;    
    }

}
