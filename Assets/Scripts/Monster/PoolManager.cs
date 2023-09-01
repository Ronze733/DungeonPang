using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. 프리펩들을 보관할 변수
    public GameObject[] _prefabs;

    // .. 풀 담당을 하는 리스트들

    List<GameObject>[] _pools;

    void Awake()
    {
        _pools = new List<GameObject>[_prefabs.Length];

        for(int index = 0; index < _pools.Length; index++)
        {
            _pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... 선택한 풀의 놀고 있는 (비활성화 된) 게임오브젝트 접근


        foreach (GameObject item in _pools[index])
        {
            if (item && !item.activeSelf)
            {
        // ... 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ... 못 찾았으면?
        if (!select && _prefabs[index] != null)
        {
            // ... 새롭게 생성하고 select 변수에 할당
            select = Instantiate(_prefabs[index], transform);
            _pools[index].Add(select);
        }

        return select;
    }

}
