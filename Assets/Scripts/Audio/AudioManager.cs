using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    [Header("#BGM")]
    public AudioClip _bgmCilp;
    public float _bgmVolume;
    AudioSource _bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] _sfxCilps;
    public float _sfxVolume;
    public int _channels;
    AudioSource[] _sfxPlayers;
    int _channelIndex;

    public enum Sfx { Arrow,Thunder,Lazer,Level,Coin,Exp}

    public void Awake()
    {
        _instance = this;
        Init();
    }

    public void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        _bgmPlayer = bgmObject.AddComponent<AudioSource>();
        _bgmPlayer.playOnAwake = false;
        _bgmPlayer.loop = true;
        _bgmPlayer.volume = _bgmVolume;
        _bgmPlayer.clip = _bgmCilp;

        // 효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        _sfxPlayers = new AudioSource[_channels];

        for (int index = 0; index < _sfxPlayers.Length; index++)
        {
            _sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            _sfxPlayers[index].playOnAwake=false;
            _sfxPlayers[index].volume = _sfxVolume;
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < _sfxPlayers.Length; index++)
        {
            int loopIndex = index + _channelIndex % _sfxPlayers.Length;
            if (_sfxPlayers[loopIndex].isPlaying)
                continue;

            _channelIndex = loopIndex;
            _sfxPlayers[0].clip = _sfxCilps[(int)sfx];
            _sfxPlayers[0].Play();
            break;
        }
       
    }
}
