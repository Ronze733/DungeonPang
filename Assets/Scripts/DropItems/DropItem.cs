using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropItem : MonoBehaviour
{
    // ���� �߰�: �������� ���ߴ� �ð�
    public float stopDuration = 1f;
    protected bool isJumping = true;
    protected Rigidbody2D rigidBody;

    // �������� ������ �� ���� ��ġ�� �����ϴ� ����
    protected Vector2 _stoppedPosition;

    // ������ ��ġ
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
            // �ְ����� �����ϰų� �ϰ� ���� �����̹Ƿ�, �������� ����
            rigidBody.velocity = Vector2.zero;
            isJumping = false;
            _stoppedPosition = transform.position; // ������ ���� ��ġ�� ���

            // 1�� �ڿ� �ٽ� �߷� �������� ���� (�߷� �������� 0���� �������� ����)
            Invoke("StopGravity", stopDuration);
        }

        // �߷��� ������ ��, ������ ��ġ�� ����� �������� ���ߵ��� ó��
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
        rigidBody.gravityScale = 0f; // �߷� ���� ����
    }
}
