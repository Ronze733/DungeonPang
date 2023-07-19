using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile = null;

    private GameObject _character = null;

    [SerializeField]
    [Range(1, 6)]
    private int _level = 1;
    private int _beforeLevel = 1;
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    [SerializeField]
    private float _shootTerm = 2f;
    private float _shootTime = Mathf.Infinity;


    // Start is called before the first frame update
    private void Awake()
    {
        _character = GameObject.FindGameObjectWithTag("Player");
        _projectile.GetComponent<Arrow>().Damage = 3;
        _projectile.GetComponent<Arrow>().Speed = 5;
        _shootTerm = 2f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_character.GetComponent<HealthPoint>().HP == 0) return;

        int projectileNum = 0;
        switch (_level)
        {
            case 1: 
                projectileNum = 1;
                break;
            case 2:
                projectileNum = 2;
                break;
            case 3:
                projectileNum = 4;
                break;
            case 4:
                projectileNum = 4;
                break;
            case 5:
                projectileNum = 4;
                break;
            case 6:
                projectileNum = 8;
                break;
            default:
                projectileNum = 8;
                break;
        }
        WeaponLevelUp(_beforeLevel);

        float direction = _character.GetComponent<PMovement>().Direction() > 0 ? 1 : -1;

        if (_shootTime > _shootTerm)
        {
            Quaternion dir = Quaternion.identity;
            _shootTime = 0;
            for(int i = 0; i <  projectileNum; i++)
            {
                if (direction == 1)
                {
                    dir = Quaternion.Euler(0, _character.transform.eulerAngles.y, i * 360 / projectileNum + 0);
                    Instantiate(_projectile, this.transform.position, dir);
                }
                else
                {
                    dir = Quaternion.Euler(0, _character.transform.eulerAngles.y, i * 360 / projectileNum + 180);
                    Instantiate(_projectile, this.transform.position, dir);
                }
            }

        }

        _shootTime += Time.deltaTime;
    }

    private void WeaponLevelUp(int beforeLevel)
    {
        if (beforeLevel == _level) return;

        _beforeLevel = _level;
        _projectile.GetComponent<Arrow>().Damage += 2;
        _projectile.GetComponent<Arrow>().Speed *= 1.2f;
        _shootTerm *= 0.8f;
    }
}
