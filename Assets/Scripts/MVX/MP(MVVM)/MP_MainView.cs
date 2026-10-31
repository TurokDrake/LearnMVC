using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_MainView : BasePanel
{
    // 获取控件的逻辑已经在 BasePanel中执行了
    // 

    // Start is called before the first frame update
    void Start()
    {
        // 第一次创建面板时需要更新数据
        UpdateInfo(PlayerModel.Data);

        // 添加监听函数
        PlayerModel.Data.AddEventListener(UpdateInfo);
    }

    protected override void OnClick(string name)
    {
        base.OnClick(name);

        switch (name)
        {
            case "btnRole":
                UIManager.GetInstance().ShowPanel<MP_RoleView>("RolePanel");
                break;
        }
    }

    private void UpdateInfo(PlayerModel data)
    {
        MP_MainView mainPanel = UIManager.GetInstance().GetPanel<MP_MainView>("MainPanel");
       if( mainPanel.gameObject.transform.Find("Left").Find("txtName").gameObject.GetComponent<Text>()==null)
        {
            Debug.Log("Left txtName Null");
            return;
        }
        mainPanel.gameObject.transform.Find("Left").Find("txtName").gameObject.GetComponent<Text>().text = data.Name;
        mainPanel.gameObject.transform.Find("Left").Find("txtLev").gameObject.GetComponent<Text>().text = data.Lev.ToString();
        mainPanel.gameObject.transform.Find("Right").Find("txtMoney").gameObject.GetComponent<Text>().text = data.Money.ToString();
        mainPanel.gameObject.transform.Find("Right").Find("txtGem").gameObject.GetComponent<Text>().text = data.Gem.ToString();
        mainPanel.gameObject.transform.Find("Right").Find("txtPower").gameObject.GetComponent<Text>().text = data.Power.ToString();

    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }

}
