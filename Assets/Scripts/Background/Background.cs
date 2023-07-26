using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float moveSpeed = 40f;
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Area"))
        {
            Vector3 playerPos = GameManager.Instance.Player.transform.position;
            Vector3 myPos = transform.position;
            float diffX = Mathf.Abs(playerPos.x - myPos.x);
            float diffY = Mathf.Abs(playerPos.y - myPos.y);

            Vector3 playerDir = GameManager.Instance.Player.transform.position - myPos;
            float dirX = playerDir.x < 0 ? -1 : 1;
            float dirY = playerDir.y < 0 ? -1 : 1;

                Debug.Log("asd");
            if(diffX > diffY)
            {
                transform.Translate(Vector3.right * dirX * moveSpeed * Time.deltaTime);
            }
            else if(diffX < diffY)
            {
                transform.Translate(Vector3.up * dirY * moveSpeed * Time.deltaTime);
            }
        }

    }
}