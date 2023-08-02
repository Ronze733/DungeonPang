using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCoolDown : UIManager
{
    private GameObject _character = null;
    private CharacterSkill _skillSytem = null;

    protected float _coolTerm = 0f;
    protected float _coolTime = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        _character = GameObject.FindGameObjectWithTag("Player");
        _skillSytem = _character.GetComponent<CharacterSkill>();
    }

    protected void GetTerm(string qwe)
    {
        switch (qwe)
        {
            case "Q":
                _coolTerm = _skillSytem.QCoolTerm;
                break;
            case "W":
                _coolTerm = _skillSytem.WCoolTerm;
                break;
            case "E":
                _coolTerm = _skillSytem.ECoolTerm;
                break;
            default:
                break;
        }
    }

    protected void GetTime(string qwe)
    {
        switch(qwe)
        {
            case "Q":
                _coolTime = _skillSytem.QCoolTime;
                break;
            case "W":
                _coolTime = _skillSytem.WCoolTime;
                break;
            case "E":
                _coolTime = _skillSytem.ECoolTime;
                break;
            default:
                break;
        }
    }

    protected void DoCoolDown()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        Vector3 rectPos = rect.anchoredPosition3D;
        float baseHeight = 0.01f;
        float changeHeight = _coolTime / _coolTerm;
        Vector3 nowHeight = gameObject.transform.localScale;

        if (_coolTime == 0f)
        {
            nowHeight.y = 0f;
            rectPos.y = -0.5f;
        }
        else
        {
            nowHeight.y = baseHeight * (1 - changeHeight);
            rectPos.y = -1 * changeHeight / 2;
        }

        gameObject.GetComponent<RectTransform>().anchoredPosition3D = rectPos;
        gameObject.transform.localScale = nowHeight;
    }
}
