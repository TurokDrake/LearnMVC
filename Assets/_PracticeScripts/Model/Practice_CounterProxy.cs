using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CounterData 对应的 代理（Proxy）
/// </summary>
public class Practice_CounterProxy : Proxy
{
    public new const string NAME = "CounterProxy"; // 覆盖父类的常量 NAME

    public Practice_CounterProxy(): base(NAME)
    {
        // 初始化数据对象
        Practice_CounterData data = new Practice_CounterData();

        data.num = (float)PlayerPrefs.GetInt("CounterNum", 0);
        data.powerOfNum =(float) PlayerPrefs.GetInt("CounterPowerOfNum", 0);

        Data = data;
    }

    // 跟数据打交道的逻辑都放在 Proxy ，由 Proxy 干

    /// <summary>
    /// 加一
    /// </summary>
    public void AddOne()
    {
        Practice_CounterData data = Data as Practice_CounterData;

        data.num++;
        SaveData();
    }

    public void SubOne()
    {
        Practice_CounterData data = Data as Practice_CounterData;

        data.num--;
        SaveData();
    }

    public void Power()
    {
        Practice_CounterData data = Data as Practice_CounterData;
        data.powerOfNum = data.num * data.num;
        SaveData();
    }

    public void CLR()
    {
        Practice_CounterData data = Data as Practice_CounterData;
        data.num = 0;
        data.powerOfNum = 0;
        SaveData();
    }

    private void SaveData()
    {
        Practice_CounterData data = Data as Practice_CounterData;

        PlayerPrefs.SetFloat("CounterNum", data.num);
        PlayerPrefs.SetFloat("CounterPowerOfNum", data.powerOfNum);
    }
}
