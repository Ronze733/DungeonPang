using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropItem : MonoBehaviour
{
    // 변수 추가: 움직임을 멈추는 시간
    public float stopDuration = 1f;
    protected bool isJumping = true;
    protected Rigidbody2D rigidBody;

    // 아이템이 점프한 후 멈춘 위치를 저장하는 변수
    protected Vector2 _stoppedPosition;

    // 아이템 가치
    private float _value = 1f;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Jump();
    }

    protected void Move()
    {
        if (isJumping && rigidBody.velocity.y <= 0)
        {
            // 최고점에 도달하거나 하강 중인 상태이므로, 움직임을 멈춤
            rigidBody.velocity = Vector2.zero;
            isJumping = false;
            _stoppedPosition = transform.position; // 코인이 멈춘 위치를 기록

            // 1초 뒤에 다시 중력 적용하지 않음 (중력 스케일을 0으로 설정하지 않음)
            Invoke("StopGravity", stopDuration);
        }

        // 중력이 해제된 후, 코인의 위치를 기록한 지점에서 멈추도록 처리
        if (!isJumping)
        {
            transform.position = _stoppedPosition;
        }
    }

    private void Jump()
    {
        float randomJumpForce = Random.Range(2f, 2f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        jumpVelocity.x = Random.Range(-2f, 2f);
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    private void StopGravity()
    {
        rigidBody.gravityScale = 0f; // 중력 영향 해제
    }
}
