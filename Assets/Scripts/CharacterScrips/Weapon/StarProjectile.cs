using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

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

    private Vector3 _movement;

    private bool _isXCollision = false;
    private bool _isYCollision = false;
    private float _collisionXTime = 0f;
    private float _collisionYTime = 0f;

    private void Awake()
    {
        if(_setSpeed != 0f)
            _speed = _setSpeed;
    }

    private void Start()
    {
        _movement = this.transform.right * _speed;
        Vector3 pos = this.transform.position;
        pos.z = -5f;
        this.transform.position = pos;
    }

    private void Update()
    {
        Vector3 position = this.transform.position;
        _movement.z = 0f;
        position += _movement * Time.deltaTime;

        this.transform.position = position;

        if(_isXCollision)
            _collisionXTime += Time.deltaTime;

        if(_isYCollision)
            _collisionYTime += Time.deltaTime;

        if(_collisionXTime > 1f)
        {
            _collisionXTime = 0.0f;
            _isXCollision = false;
        }

        if (_collisionYTime > 1f)
        {
            _collisionYTime = 0.0f;
            _isYCollision = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster" || collision.gameObject.tag == "Boss")
            collision.GetComponent<HealthPoint>().MonsterHit(_damage);
        
        if (collision.tag == "XWall" && !_isXCollision)
        {
            _movement.x *= -1;
            _isXCollision = true;
        }
        else if (collision.tag == "YWall" && !_isYCollision)
        {
            _movement.y *= -1;
            _isYCollision=true;
        }
    }
}
