using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 主面板视图
/// </summary>
public class NewMainView : MonoBehaviour
{
    // UI 文本控件 和 按钮控件
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtPower;
    public Text txtGem;

    public Button btnRole;

    /// <summary>
    /// 更新 UI文本控件内容
    /// </summary>
    /// <param name="data">玩家数据</param>
    public void UpdateInfo(PlayerDataObj data)
    {
        txtName.text = data.name;
        txtLev.text = data.lev.ToString();
        txtMoney.text = data.money.ToString();
        txtPower.text = data.power.ToString();
        txtGem.text = data.gem.ToString();
    }
}
