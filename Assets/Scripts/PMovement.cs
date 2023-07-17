using Assets.PixelHeroes.Scripts.CharacterScrips;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationState = Assets.PixelHeroes.Scripts.CharacterScrips.AnimationState;

public class PMovement : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _lerpTime;

    [SerializeField]
    private Character _character;
    [SerializeField]
    private GameObject _characterObject;

    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private float _basicAttackTime = 0.5f;

    public float _runSpeed = 2.0f;
    public ParticleSystem _moveDust;

    private Transform _transform;


    private Vector3 _cameraPosition;
    private Vector3 _position;

    private void Awake()
    {
        _transform = _characterObject.transform;
        _animator = GetComponent<Animator>();
        _position = _transform.position;

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

    private float time = Mathf.Infinity;

    // Update is called once per frame
    private void Update()
    {
        Move();
        BasicAttack();
    }

    private void BasicAttack()
    {
        if (time > _basicAttackTime)
        {
            time = 0.0f;
            _character.Animator.SetTrigger("Slash");
        }
        time += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    private void Move()
    {
        _position = _transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _position.y += _runSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _position.y -= _runSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _position.x -= _runSpeed * Time.deltaTime;
            Turn(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _position.x += _runSpeed * Time.deltaTime;
            Turn(1);
        }

        if (_transform.position == _position)
        {
            _character.Animator.SetBool("Idle", true);
            _character.Animator.SetBool("Running", false);
            if (_moveDust.isPlaying)
                _moveDust.Pause();
        }
        else
        {
            _character.Animator.SetBool("Idle", false);
            _character.Animator.SetBool("Running", true);
            _transform.position = _position;
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
