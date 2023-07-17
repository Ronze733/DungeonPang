 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    Transform mosterTransform;
    Monster monster;

    Rigidbody2D rb;
    Transform target;

    [SerializeField]
    float moveSpeed = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }


}
