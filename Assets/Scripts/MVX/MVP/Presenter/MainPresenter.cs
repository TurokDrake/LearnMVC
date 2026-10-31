using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    private MVP_MainView _mainView; // 获取主视图中的控件

    private static MainPresenter _presenter; // 单例
    public static MainPresenter Presenter
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
            _presenter = GetComponent<MainPresenter>();
        }

        // 顺便找到面板上的 MainView
        _mainView = GetComponent<MVP_MainView>();

        // 初始化数据
        UpdateInfo(PlayerModel.Data);

        PlayerModel.Data.AddEventListener(UpdateInfo);
        // 为按钮绑定事件
        _mainView.btnRole.onClick.AddListener(() =>
        {
            // 打开角色面板
            RolePresenter.ShowPanel();
            PlayerModel.Data.Init();
        });
    }

    // 通过 controller 控制面板的显隐
    public static void ShowPanel()
    {
        if (_presenter == null)
        {
            GameObject mainPanelAssets = Resources.Load<GameObject>("UI/MainPanel");
            GameObject mainPanel = Instantiate(mainPanelAssets, GameObject.Find("Canvas").transform);
            _presenter = mainPanel.GetComponent<MainPresenter>();
        }

        _presenter.gameObject.SetActive(true);
        PlayerModel.Data.SaveData();
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



    // 更新数据信息
    private void UpdateInfo(PlayerModel data)
    {
        _mainView.txtName.text = data.Name;
        _mainView.txtLev.text = data.Lev.ToString();
        _mainView.txtMoney.text = data.Money.ToString();
        _mainView.txtPower.text = data.Power.ToString();
        _mainView.txtGem.text = data.Gem.ToString();
    }

    // 当面板实例被移除时，需要删除按钮的监听函数
    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
