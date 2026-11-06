using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 角色面板视图
/// </summary>
public class NewRoleView : MonoBehaviour
{
    // UI 文本控件以及按钮控件
    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrit;
    public Text txtMiss;
    public Text txtLuck;

    public Button btnClose;
    public Button btnLevUp;

    /// <summary>
    /// 更新面板数据
    /// </summary>
    /// <param name="data">玩家数据</param>
    public void UpdateInfo(PlayerDataObj data)
    {
        txtLev.text = data.lev.ToString();
        txtHp.text = data.hp.ToString();
        txtAtk.text = data.atk.ToString();
        txtDef.text = data.def.ToString();
        txtCrit.text = data.crit.ToString();
        txtMiss.text = data.miss.ToString();
        txtLuck.text = data.luck.ToString();
    }
}
