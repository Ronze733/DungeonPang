using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))
        {
                Debug.Log("asd");

            Vector3 playerPos = GameManager.Instance.Player.transform.position;
            Vector3 myPos = transform.position;
            float diffX = Mathf.Abs(playerPos.x - myPos.x);
            float diffY = Mathf.Abs(playerPos.y - myPos.y);

            Vector3 playerDir = GameManager.Instance.Player.transform.position - myPos;
            float dirX = playerDir.x < 0 ? -1 : 1;
            float dirY = playerDir.y < 0 ? -1 : 1;

            if(diffX > diffY)
            {
                transform.Translate(Vector3.right * dirX * 40);
            }
            else if(diffX < diffY)
            {
                transform.Translate(Vector3.up * dirX * 40);
            }
        }

    }
}