using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _damage = 0f;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            // ���� ������Ʈ�� BoxCollider2D ������Ʈ ��������
            BoxCollider2D attackRangeCollider = GetComponent<BoxCollider2D>();

            // BoxCollider2D�� ���� ���� �ִ� ��� ���� ã��
            Collider2D[] hitMonsters = Physics2D.OverlapBoxAll(transform.position, attackRangeCollider.size, attackRangeCollider.transform.rotation.eulerAngles.z);

            // ã�� ���͵鿡�� ������ ������
            foreach (Collider2D monsterCollider in hitMonsters)
            {
                if (monsterCollider.CompareTag("Monster"))
                {
                    monsterCollider.GetComponent<HealthPoint>().MonsterHit(_damage);
                }
            }
        }
    }
}
