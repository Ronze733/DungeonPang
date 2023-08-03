using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("RealPlayer"))
            return;

        Vector3 playerPos = GameObject.FindGameObjectWithTag("RealPlayer").transform.position;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = _player.GetComponent<PMovement>().InputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        // Debug.Log(dirX);
        // Debug.Log(dirY);

        if (diffX > diffY)
            transform.Translate(Vector3.right * dirX * 80);
        else if (diffX < diffY)
            transform.Translate(Vector3.up * dirY * 80);

    }

}