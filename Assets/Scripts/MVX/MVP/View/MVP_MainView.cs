using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVP_MainView : MonoBehaviour
{
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtPower;
    public Text txtGem;

    public Button btnRole;

    // MVP 中，根据数据更新面板放在了 Presenter 中
}
