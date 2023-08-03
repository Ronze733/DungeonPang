using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrollHpBarController : MonoBehaviour
{
    private HealthPoint _hp = null;

    [SerializeField]
    private GameObject _maxHpBar;
    [SerializeField]
    private GameObject _nowHpBar;

    private float _beforeHp;

    private void Start()
    {
        _hp = GameObject.FindGameObjectWithTag("Boss").GetComponent<HealthPoint>();
        _beforeHp = _hp.MaxHP;
    }

    private void Update()
    {
        float maxHp = _hp.MaxHP;
        float nowHp = _hp.HP;

        if (maxHp == nowHp)
        {
            _maxHpBar.gameObject.SetActive(true);
            _nowHpBar.gameObject.SetActive(true);
        }

        if (nowHp < maxHp)
        {
            _maxHpBar.gameObject.SetActive(true);
            _nowHpBar.gameObject.SetActive(true);

            if (_beforeHp == nowHp) return;

            Vector3 size = _maxHpBar.transform.localScale;
            size.x *= nowHp / maxHp;
            _nowHpBar.transform.localScale = size;
            _beforeHp = nowHp;
        }
    }
}
