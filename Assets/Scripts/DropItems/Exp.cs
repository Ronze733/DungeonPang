using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : DropItem
{
    private int _beforeTime = 1;

    // Update is called once per frame
    private void Update()
    {
        Move();
        float time = GameManager.Instance.GameTime;
        if(((int)time ) / 70 != _beforeTime && time > 70)
        {
            _beforeTime = ((int)time) / 70;
            _value *= 2;
        }
    }


}
