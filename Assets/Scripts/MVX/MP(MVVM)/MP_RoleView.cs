using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_RoleView : BasePanel
{

    private void Start()
    {
        UpdateInfo(PlayerModel.Data);

        PlayerModel.Data.AddEventListener(UpdateInfo);
    }

    protected override void OnClick(string name)
    {
        base.OnClick(name);

        switch (name)
        {
            case "btnClose":
                UIManager.GetInstance().HidePanel("RolePanel");
                break;
            case "btnLevUp":
                PlayerModel.Data.LevUp();
                break;
        }
    }

    private void UpdateInfo(PlayerModel data)
    {
        MP_RoleView rolePanel=UIManager.GetInstance().GetPanel<MP_RoleView>("RolePanel");
        rolePanel.gameObject.transform.Find("Info").Find("txtLev").gameObject.GetComponent<Text>().text = data.Lev.ToString();
        rolePanel.gameObject.transform.Find("Info").Find("txtHp").gameObject.GetComponent<Text>().text = data.Hp.ToString();
        rolePanel.gameObject.transform.Find("Info").Find("txtAtk").gameObject.GetComponent<Text>().text = data.Atk.ToString();
        rolePanel.gameObject.transform.Find("Info").Find("txtDef").gameObject.GetComponent<Text>().text = data.Def.ToString();
        rolePanel.gameObject.transform.Find("Info").Find("txtMiss").gameObject.GetComponent<Text>().text = data.Miss.ToString();
        rolePanel.gameObject.transform.Find("Info").Find("txtCrit").gameObject.GetComponent<Text>().text = data.Crit.ToString();
        rolePanel.gameObject.transform.Find("Info").Find("txtLuck").gameObject.GetComponent<Text>().text = data.Luck.ToString();

    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
