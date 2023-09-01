using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QCool : SkillCoolDown
{
    private void Start()
    {
        GetTerm("Q");
    }

    private void Update()
    {
        GetTime("Q");
        DoCoolDown();
    }
}
