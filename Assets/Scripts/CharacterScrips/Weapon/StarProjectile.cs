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

    [SerializeField]
    private float _setSpeed;

    public float SetSpeed
    {
        get { return _setSpeed; }
        set { _setSpeed = value; }
    }

    private float _speed = 3f;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Awake()
    {
        if(_setSpeed != 0f)
            _speed = _setSpeed;
    }

    private void Update()
    {
        Transform star = this.transform;
        star.Translate(star.right * _speed * Time.deltaTime, Space.World);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            // 현재 오브젝트의 BoxCollider2D 컴포넌트 가져오기
            BoxCollider2D attackRangeCollider = GetComponent<BoxCollider2D>();

            // BoxCollider2D의 범위 내에 있는 모든 몬스터 찾기
            Collider2D[] hitMonsters = Physics2D.OverlapBoxAll(transform.position, attackRangeCollider.size, attackRangeCollider.transform.rotation.eulerAngles.z);

            // 찾은 몬스터들에게 데미지 입히기
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
