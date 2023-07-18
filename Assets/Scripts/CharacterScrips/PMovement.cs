using Assets.PixelHeroes.Scripts.CharacterScrips;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationState = Assets.PixelHeroes.Scripts.CharacterScrips.AnimationState;

public class PMovement : MonoBehaviour
{
    [SerializeField]
    private bool _isInvincibility = false;

    [SerializeField]
    private float _lerpTime;

    [SerializeField]
    private Character _character;
    [SerializeField]
    private GameObject _characterObject;

    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    [Range(0.8f, 1.2f)]
    private float _jumpRange;

    public float _runSpeed = 2.0f;
    public ParticleSystem _moveDust;

    private Transform _transform;

    private HealthPoint _healthPoint;


    private Vector3 _cameraPosition;
    private Vector3 _position;

    [SerializeField]
    private float _invicibilityTime = 0.5f;
    private float _invicibility = 0f;

    // private bool _isMoving = false;

    private void Awake()
    {
        _transform = _characterObject.transform;
        _position = _transform.position;

        _healthPoint = GetComponent<HealthPoint>();

        Vector3 cameraPos;
        cameraPos.z = -600f;
        cameraPos.x = _position.x;
        cameraPos.y = _position.y;

        _camera.transform.position = cameraPos;
        _cameraPosition = _camera.transform.position;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _character.SetState(AnimationState.Idle);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_healthPoint.HP == 0)
        {
            _character.Animator.SetBool("Idle", false);
            _character.Animator.SetBool("Running", false);
            _character.Animator.SetBool("Dead", true);
            return;
        }


        /*
        if(_damageTime > 2)
        {
            _healthPoint.Hit(5, _damageTime);
            _damageTime = 0f;
        }
        */

        _invicibility += Time.deltaTime;
        Move();

        if (_invicibility >= _invicibilityTime)
            _isInvincibility = false;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster" && !_isInvincibility)
        {
            Vector2 collider = this.gameObject.GetComponent<Collider2D>().offset;
            if (collision.GetComponent<HealthPoint>().HP == 0) return;
            Damage monster = collision.GetComponent<Damage>();
            _healthPoint.Hit(monster.DamageValue);
            _isInvincibility = true;

            Vector3 _dir = _position - collision.transform.position;

            if (_dir.x < 0)
            {
                _position.x -= _jumpRange;
                collider.x -= _jumpRange;
            }
            else
            {
                _position.x += _jumpRange;
                collider.x += _jumpRange;
            }

            /*
            if(_dir.y < 0)
            {
                _position.y += _jumpRange;
                collider.y += _jumpRange;
            }
            else
            {
                _position.y -= _jumpRange;
                collider.y -= _jumpRange;
            }
            */

            _transform.position = _position;
            this.gameObject.GetComponent<Collider2D>().offset = collider;
            _invicibility = 0.0f;
        }


    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_healthPoint.HP != 0)
        {
            if (collision.gameObject.tag == "Monster")
            {
                if (_damageTime > _damageTimeTerm)
                {
                    Damage monster = collision.gameObject.GetComponent<Damage>();
                    _healthPoint.Hit(monster.DamageValue);
                    _damageTime = 0;
                }
            }
        }
    }
    */

    private void FixedUpdate()
    {
        CameraMove();
    }

    private void Move()
    {
        Vector2 collider = this.gameObject.GetComponent<Collider2D>().offset;
        _position = _transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            collider.y += _runSpeed * Time.deltaTime;
            _position.y += _runSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            collider.y -= _runSpeed * Time.deltaTime;
            _position.y -= _runSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            collider.x -= _runSpeed * Time.deltaTime;
            _position.x -= _runSpeed * Time.deltaTime;
            Turn(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            collider.x += _runSpeed * Time.deltaTime;
            _position.x += _runSpeed * Time.deltaTime;
            Turn(1);
        }

        if (_transform.position == _position)
        {
            _character.Animator.SetBool("Idle", true);
            _character.Animator.SetBool("Running", false);
            if (_moveDust.isPlaying)
                _moveDust.Pause();
            // _isMoving = false;
        }
        else
        {
            _character.Animator.SetBool("Idle", false);
            _character.Animator.SetBool("Running", true);
            _transform.position = _position;
            // _isMoving = true;
            this.gameObject.GetComponent<Collider2D>().offset = collider;
            if (!_moveDust.isPlaying)
                _moveDust.Play();
        }

    }

    private void Turn(int direction)
    {
        var scale = _character.transform.localScale;

        scale.x = Mathf.Sign(direction) * Mathf.Abs(scale.x);

        _character.transform.localScale = scale;
    }

    /*
    private void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.A)) _character.Animator.SetTrigger("Attack");
        else if (Input.GetKeyDown(KeyCode.J)) _character.Animator.SetTrigger("Jab");
        else if (Input.GetKeyDown(KeyCode.P)) _character.Animator.SetTrigger("Push");
        else if (Input.GetKeyDown(KeyCode.H)) _character.Animator.SetTrigger("Hit");
        else if (Input.GetKeyDown(KeyCode.I)) { _character.SetState(AnimationState.Idle); _activityTime = 0; }
        else if (Input.GetKeyDown(KeyCode.R)) { _character.SetState(AnimationState.Ready); _activityTime = Time.time; }
        else if (Input.GetKeyDown(KeyCode.B)) _character.SetState(AnimationState.Blocking);
        else if (Input.GetKeyUp(KeyCode.B)) _character.SetState(AnimationState.Ready);
        else if (Input.GetKeyDown(KeyCode.D)) _character.SetState(AnimationState.Dead);

        // Builder characters only.
        else if (Input.GetKeyDown(KeyCode.S)) _character.Animator.SetTrigger("Slash");
        else if (Input.GetKeyDown(KeyCode.O)) _character.Animator.SetTrigger("Shot");
        else if (Input.GetKeyDown(KeyCode.F)) _character.Animator.SetTrigger("Fire1H");
        else if (Input.GetKeyDown(KeyCode.E)) _character.Animator.SetTrigger("Fire2H");
        else if (Input.GetKeyDown(KeyCode.C)) _character.SetState(AnimationState.Climbing);
        else if (Input.GetKeyUp(KeyCode.C)) _character.SetState(AnimationState.Ready);
        else if (Input.GetKeyUp(KeyCode.L)) _character.Blink();
    }
    */

    private void CameraMove()
    {
        // _position, _cameraPosition

        Vector3 targetPos = _position;
        targetPos.z = -600f;

        _cameraPosition = Vector3.Lerp(_cameraPosition, targetPos, _lerpTime * Time.deltaTime);
        _camera.transform.position = _cameraPosition;
    }

}
