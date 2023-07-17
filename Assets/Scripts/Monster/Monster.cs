using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float _attackRange = 1f;

    public float _speed;
    private Vector2 _dir;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _dir = _player.transform.position - this.transform.position;
        if (_player != null)
        {
            if (_dir.magnitude < 1.0f)
                this.gameObject.GetComponent<Animator>().SetBool("isFollow", true);
            else
                this.gameObject.GetComponent<Animator>().SetBool("isFollow", false);
        }

        if (_dir.x < 0)
            Turn(-1);
        else if (_dir.x > 0)
            Turn(1);
        
    }

    private void Turn(int direction)
    {
        var scale = this.gameObject.transform.localScale;

        scale.x = Mathf.Sign(direction) * Mathf.Abs(scale.x);

        gameObject.transform.localScale = scale;

    }
}
