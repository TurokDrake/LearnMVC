using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    private RoleView _roleView; // 获取主视图中的控件

    private static RoleController _controller; // 单例
    public static RoleController Controller
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
            _controller = GetComponent<RoleController>();
        }
        // 顺便找到面板上的 RoleView
        _roleView = GetComponent<RoleView>();

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
        if (_controller == null)
        {
            GameObject mainPanelAssets = Resources.Load<GameObject>("UI/RolePanel");
            GameObject mainPanel = Instantiate(mainPanelAssets, GameObject.Find("Canvas").transform);
            _controller = mainPanel.GetComponent<RoleController>();
        }
        _controller.gameObject.SetActive(true);
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

    private void UpdateInfo(PlayerModel data)
    {
        _roleView.UpdateInfo(data);
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
