using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private MainView _mainView; // 获取主视图中的控件

    private static MainController _controller; // 单例
    public static MainController Controller
    {
        get
        {
            if (_controller == null)
            {
                Debug.Log("MainController为空！");
            }
            return _controller;
        }
    }

    private void Start()
    {
        // 在面板创建好后，检查一遍_controller是否为空；获取 controller
        if (_controller == null)
        {
            _controller = GetComponent<MainController>();
        }

        // 顺便找到面板上的 MainView
        _mainView = GetComponent<MainView>();

        // 初始化数据
        UpdateInfo(PlayerModel.Data);
        PlayerModel.Data.AddEventListener(UpdateInfo);
        // 为按钮绑定事件
        _mainView.btnRole.onClick.AddListener(() =>
        {
            // 打开角色面板
            RoleController.ShowPanel();
            PlayerModel.Data.Init();
        });
    }

    // 通过 controller 控制面板的显隐
    public static void ShowPanel()
    {
        if (_controller == null)
        {
            GameObject mainPanelAssets = Resources.Load<GameObject>("UI/MainPanel");
            GameObject mainPanel = Instantiate(mainPanelAssets, GameObject.Find("Canvas").transform);
            _controller = mainPanel.GetComponent<MainController>();
        }

        _controller.gameObject.SetActive(true);
        PlayerModel.Data.SaveData();
    }
    public static void HidePanel()
    {
        if (_controller != null)
        {
            //Destroy(INSTANCE.gameObject);
            //INSTANCE = null;
            _controller.gameObject.SetActive(false);
        }
    }

    

    // 更新数据信息
    private void UpdateInfo(PlayerModel data)
    {
        _mainView.UpdateInfo(data);
    }

    // 当面板实例被移除时，需要删除按钮的监听函数
    private void OnDestroy()
    {
    }
}
