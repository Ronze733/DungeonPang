using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCool : SkillCoolDown
{
    private void Start()
    {
        GetTerm("W");
    }

    private void Update()
    {
        GetTime("W");
        DoCoolDown();
    }
}
