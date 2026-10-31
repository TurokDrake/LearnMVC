using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel
{
    private static PlayerModel _data;
    public static PlayerModel Data
    {
        get
        {
            if (_data == null)
            {
                _data = new PlayerModel();
                _data.Init();
            }
            return _data;
        }
    }

    // 数据层面
    private int _gem;
    public int Gem
    {
        get
        {
            return _gem;
        }
    }

    private int _power;
    public int Power
    {
        get
        {
            return _power;
        }
    }

    private int _money;
    public int Money
    {
        get
        {
            return _money;
        }
    }

    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
    }

    private int _lev;
    public int Lev
    {
        get
        {
            return _lev;
        }
    }

    private int _hp;
    public int Hp
    {
        get
        {
            return _hp;
        }
    }
    private int _atk;
    public int Atk
    {
        get
        {
            return _atk;
        }
    }
    private int _def;
    public int Def
    {
        get
        {
            return _def;
        }
    }
    private int _crit;
    public int Crit
    {
        get
        {
            return _crit;
        }
    }
    private int _miss;
    public int Miss
    {
        get
        {
            return _miss;
        }
    }
    private int _luck;
    public int Luck
    {
        get
        {
            return _luck;
        }
    }

    private event UnityAction<PlayerModel> _dataEvent;

    // 初始化数据
    public void Init()
    {
        _name = PlayerPrefs.GetString("PlayerName", "Turok");
        _money = PlayerPrefs.GetInt("PlayerMoney", 100);
        _gem = PlayerPrefs.GetInt("PlayerGem", 99);
        _power = PlayerPrefs.GetInt("PlayerPower", 200);

        _lev = PlayerPrefs.GetInt("PlayerLev", 1);
        _hp = PlayerPrefs.GetInt("PlayerHp", 10);
        _atk = PlayerPrefs.GetInt("PlayerAtk", 10);
        _def = PlayerPrefs.GetInt("PlayerDef", 5);
        _crit = PlayerPrefs.GetInt("PlayerCrit", 8);
        _miss = PlayerPrefs.GetInt("PlayerMiss", 2);
        _luck = PlayerPrefs.GetInt("PlayerLuck", 3);
    }

    // 用于清空数据
    public void Clear()
    {
        _lev = 1;
        _hp = 10;
        _atk = 10;
        _def = 5;
        _crit = 8;
        _miss = 2;
        _luck = 3;

        SaveData();
    }

    // 修改操作，在这里就用简单的升级替代；一般开发过程中有很多修改，例如专门修改生命值、专门修改魔法值的修改
    public void LevUp()
    {
        // 简单处理一下逻辑
        _lev += 1;

        _hp += _lev;
        _atk += _lev;
        _def += _lev;
        _crit += _lev;
        _miss += _lev;
        _luck += _lev;

        // 再保存数据
        SaveData();
    }

    // 保存数据，将当前数据写到磁盘
    public void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", _name);
        PlayerPrefs.SetInt("PlayerLev", _lev);
        PlayerPrefs.SetInt("PlayerGem", _gem);
        PlayerPrefs.SetInt("PlayerMoney", _money);
        PlayerPrefs.SetInt("PlayerPower", _power);

        PlayerPrefs.SetInt("PlayerHp", _hp);
        PlayerPrefs.SetInt("PlayerAtk", _atk);
        PlayerPrefs.SetInt("PlayerDef", _def);
        PlayerPrefs.SetInt("PlayerCrit", _crit);
        PlayerPrefs.SetInt("PlayerMiss", _miss);
        PlayerPrefs.SetInt("PlayerLuck", _luck);

        UpdateInfo();
    }

    // 添加监听函数，是为了在保存数据后一起执行这些方法
    public void AddEventListener(UnityAction<PlayerModel> function)
    {
        _dataEvent += function;
    }
    // 对应地移除监听函数的方法
    public void RemoveEventListener(UnityAction<PlayerModel> function)
    {
        _dataEvent -= function;
    }

    private void UpdateInfo()
    {
        if (_dataEvent != null)
        {
            _dataEvent.Invoke(this);
        }
    }
}
