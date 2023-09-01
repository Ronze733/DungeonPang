using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. ��������� ������ ����
    public GameObject[] _prefabs;

    // .. Ǯ ����� �ϴ� ����Ʈ��

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

        // ... ������ Ǯ�� ��� �ִ� (��Ȱ��ȭ ��) ���ӿ�����Ʈ ����


        foreach (GameObject item in _pools[index])
        {
            if (item && !item.activeSelf)
            {
        // ... �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ... �� ã������?
        if (!select && _prefabs[index] != null)
        {
            // ... ���Ӱ� �����ϰ� select ������ �Ҵ�
            select = Instantiate(_prefabs[index], transform);
            _pools[index].Add(select);
        }

        return select;
    }

}
