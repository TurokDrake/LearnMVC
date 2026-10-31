using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolePresenter : MonoBehaviour
{
    private MVP_RoleView _roleView; // 获取主视图中的控件

    private static RolePresenter _presenter; // 单例
    public static RolePresenter Presenter
    {
        get
        {
            if (_presenter == null)
            {
                Debug.Log("MainController为空！");
            }
            return _presenter;
        }
    }

    private void Start()
    {
        // 在面板创建好后，检查一遍_controller是否为空；获取 controller
        if (_presenter == null)
        {
            _presenter = GetComponent<RolePresenter>();
        }
        // 顺便找到面板上的 RoleView
        _roleView = GetComponent<MVP_RoleView>();

        UpdateInfo(PlayerModel.Data);
        PlayerModel.Data.AddEventListener(UpdateInfo);

        // 为按钮绑定事件
        _roleView.btnClose.onClick.AddListener(() =>
        {
            // 关闭窗口
            HidePanel();

        });

        _roleView.btnLevUp.onClick.AddListener(() =>
        {
            // 升级的逻辑
            PlayerModel.Data.LevUp();
        });

    }



    public static void ShowPanel()
    {
        if (_presenter == null)
        {
            GameObject mainPanelAssets = Resources.Load<GameObject>("UI/RolePanel");
            GameObject mainPanel = Instantiate(mainPanelAssets, GameObject.Find("Canvas").transform);
            _presenter = mainPanel.GetComponent<RolePresenter>();
        }
        _presenter.gameObject.SetActive(true);
    }
    public static void HidePanel()
    {
        if (_presenter != null)
        {
            //Destroy(INSTANCE.gameObject);
            //INSTANCE = null;
            _presenter.gameObject.SetActive(false);
        }
    }

    private void UpdateInfo(PlayerModel data)
    {
        _roleView.txtLev.text = data.Lev.ToString();
        _roleView.txtHp.text = data.Hp.ToString();
        _roleView.txtAtk.text = data.Atk.ToString();
        _roleView.txtDef.text = data.Def.ToString();
        _roleView.txtCrit.text = data.Crit.ToString();
        _roleView.txtMiss.text = data.Miss.ToString();
        _roleView.txtLuck.text = data.Luck.ToString();
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
