using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// 玩家数据类对于的代理类
/// </summary>
public class PlayerProxy : Proxy
{
    public new const string NAME = "PlayerProxy";

    // 构造函数，Facade会管理这个类
    public PlayerProxy() : base(NAME)
    {
        PlayerDataObj data = new PlayerDataObj();

        // 初始化好一个数据，并交付给 Proxy 的 Data
        data.name = PlayerPrefs.GetString("PlayerName", "Turok");
        data.money = PlayerPrefs.GetInt("PlayerMoney", 100);
        data.gem = PlayerPrefs.GetInt("PlayerGem", 99);
        data.power = PlayerPrefs.GetInt("PlayerPower", 200);

        data.lev = PlayerPrefs.GetInt("PlayerLev", 1);
        data.hp = PlayerPrefs.GetInt("PlayerHp", 10);
        data.atk = PlayerPrefs.GetInt("PlayerAtk", 10);
        data.def = PlayerPrefs.GetInt("PlayerDef", 5);
        data.crit = PlayerPrefs.GetInt("PlayerCrit", 8);
        data.miss = PlayerPrefs.GetInt("PlayerMiss", 2);
        data.luck = PlayerPrefs.GetInt("PlayerLuck", 3);

        Data = data; // 里氏替换原则，用父类容器装子类
    }

    /// <summary>
    /// 升级
    /// </summary>
    public void LevUp()
    {
        PlayerDataObj data = Data as PlayerDataObj;

        data.lev += 1;

        data.hp += data.lev;
        data.atk += data.lev;
        data.def += data.lev;
        data.crit += data.lev;
        data.miss += data.lev;
        data.luck += data.lev;

        SaveData();
    }

    public void SaveData()
    {
        PlayerDataObj data = Data as PlayerDataObj;

        PlayerPrefs.SetString("PlayerName", data.name);
        PlayerPrefs.SetInt("PlayerLev", data.lev);
        PlayerPrefs.SetInt("PlayerGem", data.gem);
        PlayerPrefs.SetInt("PlayerMoney", data.money);
        PlayerPrefs.SetInt("PlayerPower", data.power);

        PlayerPrefs.SetInt("PlayerHp", data.hp);
        PlayerPrefs.SetInt("PlayerAtk", data.atk);
        PlayerPrefs.SetInt("PlayerDef", data.def);
        PlayerPrefs.SetInt("PlayerCrit", data.crit);
        PlayerPrefs.SetInt("PlayerMiss", data.miss);
        PlayerPrefs.SetInt("PlayerLuck", data.luck);
    }

    
}
