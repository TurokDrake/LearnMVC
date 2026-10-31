using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    // 控件
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtPower;
    public Text txtGem;

    public Button btnRole;

    // 提供给外部修改控件的方法
    public void UpdateInfo(PlayerModel data)
    {
        txtName.text = data.Name;
        txtLev.text = data.Lev.ToString();
        txtMoney.text = data.Money.ToString();
        txtPower.text = data.Power.ToString();
        txtGem.text = data.Gem.ToString();
    }
}
