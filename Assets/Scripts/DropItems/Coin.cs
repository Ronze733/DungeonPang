using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    private void Jump()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(2f, 2f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        jumpVelocity.x = Random.Range(-2f, 2f);
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
