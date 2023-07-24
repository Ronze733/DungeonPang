using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // ���� �߰�: �������� ���ߴ� �ð�
    public float stopDuration = 1f;
    private bool isJumping = true;
    private Rigidbody2D rigidBody;

    // ������ ������ �� ���� ��ġ�� �����ϴ� ����
    private Vector2 stoppedPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Jump();
    }

    private void Jump()
    {
        float randomJumpForce = Random.Range(2f, 2f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        jumpVelocity.x = Random.Range(-2f, 2f);
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping && rigidBody.velocity.y <= 0)
        {
            // �ְ����� �����ϰų� �ϰ� ���� �����̹Ƿ�, �������� ����
            rigidBody.velocity = Vector2.zero;
            isJumping = false;
            stoppedPosition = transform.position; // ������ ���� ��ġ�� ���

            // 1�� �ڿ� �ٽ� �߷� �������� ���� (�߷� �������� 0���� �������� ����)
            Invoke("StopGravity", stopDuration);
        }

        // �߷��� ������ ��, ������ ��ġ�� ����� �������� ���ߵ��� ó��
        if (!isJumping)
        {
            transform.position = stoppedPosition;
        }
    }

    private void StopGravity()
    {
        rigidBody.gravityScale = 0f; // �߷� ���� ����
    }
}
