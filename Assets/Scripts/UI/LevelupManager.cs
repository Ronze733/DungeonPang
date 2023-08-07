using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelupManager : UIManager
{
    [SerializeField]
    private GameObject _character = null;

    [SerializeField]
    private GameObject _levelUpUI = null;

    [SerializeField]
    private TextMeshProUGUI _arrow;
    private float _fontSize = 15.0f;

    [SerializeField]
    private TextMeshProUGUI _thunder;

    [SerializeField]
    private TextMeshProUGUI _star;


    private void Start()
    {
        _levelUpUI.SetActive(false);
        _arrow.text = "BasicWeapon";
        _arrow.fontSize = 10.0f;
        _thunder.text = "Thunder!!";
        _thunder.fontSize = _fontSize;
        _star.text = "Star";
        _star.fontSize = _fontSize;
    }

    public void LevelUp()
    {
        int basicWeaponLevel = _character.GetComponentInChildren<BasicWeapon>().Level;
        int ThunderLevel = _character.GetComponentInChildren<Thunder>().WeaponLevel;
        int StarLevel = _character.GetComponentInChildren<Star>().WeaponLevel;

        if(basicWeaponLevel == 6)
            _arrow.text = "Master";
        if(ThunderLevel == 6)
            _thunder.text = "Master";
        if (StarLevel == 6)
            _star.text = "Master";

        if (basicWeaponLevel != 6 || ThunderLevel != 6 || StarLevel != 6)
        {
            _levelUpUI.SetActive(true);
            Time.timeScale = 0.0f;
            _isPaused = true;
        }
    }

    private int _state = 0;
    public int State
    {
        set { _state = value; }
    }

    private void Update()
    {
        bool isLevelUp = _levelUpUI.activeSelf;
        if(isLevelUp)
        {
            List<string> weapon = new List<string>();
            if (_arrow.text != "Master")
                weapon.Add("Arrow");

            if (_thunder.text != "Master")
                weapon.Add("Thunder");

            if (_star.text != "Master")
                weapon.Add("Star");

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _state++;
                if (_state >= weapon.Count)
                    _state = 0;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _state--;
                if (_state < 0)
                    _state = weapon.Count - 1;
            }

            string weaponName = weapon[_state];

            Color color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
            Color motoColor = new Color(1f, 1f, 1f, 1f);

            switch(weaponName)
            {
                case "Arrow":
                    _arrow.GetComponentInParent<Image>().color = color;
                    _thunder.GetComponentInParent<Image>().color = motoColor;
                    _star.GetComponentInParent<Image>().color = motoColor;
                    break;
                case "Thunder":
                    _arrow.GetComponentInParent<Image>().color = motoColor;
                    _thunder.GetComponentInParent<Image>().color = color;
                    _star.GetComponentInParent<Image>().color = motoColor;
                    break;
                case "Star":
                    _arrow.GetComponentInParent<Image>().color = motoColor;
                    _thunder.GetComponentInParent<Image>().color = motoColor;
                    _star.GetComponentInParent<Image>().color = color;
                    break;
                default:
                    break;
            }

            if(Input.GetKeyUp(KeyCode.Return))
            {
                switch(weaponName)
                {
                    case "Arrow":
                        selectBasicWeapon();
                        break;
                    case "Thunder":
                        selectThunder();
                        break;
                    case "Star":
                        selectStar();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void restartGame()
    {
        _levelUpUI.SetActive(false);
        Time.timeScale = 1.0f;
        _isPaused = false;
    }

    public void selectBasicWeapon()
    {
        int level = _character.GetComponentInChildren<BasicWeapon>().Level;
        if(level < 6)
        {
            _character.GetComponentInChildren<BasicWeapon>().Level += 1;
            restartGame();
        }
    }

    public void selectThunder()
    {
        bool canThunder = _character.GetComponentInChildren<Thunder>().CanWeapon;
        int level = _character.GetComponentInChildren<Thunder>().WeaponLevel;
        if(!canThunder)
        {
            _character.GetComponentInChildren<Thunder>().CanWeapon = true;
            restartGame();
        }
        else if (level < 6)
        {
            _character.GetComponentInChildren<Thunder>().WeaponLevel += 1;
            restartGame();
        }
    }

    public void selectStar()
    {
        bool canStar = _character.GetComponentInChildren<Star>().CanWeapon;
        int level = _character.GetComponentInChildren<Star>().WeaponLevel;

        if(!canStar)
        {
            _character.GetComponentInChildren<Star>().CanWeapon = true;
            restartGame();
        }
        else if (level < 6)
        {
            _character.GetComponentInChildren<Star>().WeaponLevel += 1;
            restartGame();
        }
    }

}
