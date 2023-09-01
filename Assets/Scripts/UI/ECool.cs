using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECool : SkillCoolDown
{
    private void Start()
    {
        GetTerm("E");
    }

    private void Update()
    {
        GetTime("E");
        DoCoolDown();
    }
}
