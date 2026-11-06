using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 显示面板的命令
public class ShowPanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        // notification.Body 中存放的应为我们想创建的面板的名字
        // 使用字符串变量存储下该信息，并根据该信息来决定创建哪个面板
        string panelName = notification.Body.ToString();

        switch (panelName)
        {
            case "MainPanel":
                // 显示主面板的逻辑
                // 如果没有创建并注册 NewMainViewMediator
                if (!Facade.HasMediator(NewMainViewMediator.NAME))
                {
                    // 注册 NewMainViewMediator
                    Facade.RegisterMediator(new NewMainViewMediator());
                }

                NewMainViewMediator mainViewMediator = Facade.RetrieveMediator(NewMainViewMediator.NAME) as NewMainViewMediator;

                // 如果 mainViewMediator 中的 ViewComponent 为空
                // 表明我们没有创建面板，也没有建立 MainView 和 MainViewMediator 间的联系
                if (mainViewMediator.ViewComponent == null)
                {
                    // 1. 同步加载 MainPanel 资源；2. 实例化 MainPanel 到场景中；3. 用 MainViewMediator 的 ViewComponent 保存 MainView
                    // 第3步是为了建立起 UI面板和 Mediator 间的联系
                    GameObject mainPanelAssets = Resources.Load<GameObject>("UI/MainPanel");
                    GameObject mainPanel = GameObject.Instantiate(mainPanelAssets, GameObject.Find("Canvas").transform);
                    // mainViewMediator.ViewComponent = mainPanel.GetComponent<NewMainView>();
                    // NewMainViewMediator 的 SetView()不仅建立起 UI控件和 Mediator 的联系
                    // 还为按钮绑定了事件
                    mainViewMediator.SetView(mainPanel.GetComponent<NewMainView>());
                }

                // 显示面板后，更新数据
                // 发送通知时，通知中的 Body 存放的是数据
                SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);

                break;

            case "RolePanel":
                // 显示角色面板的逻辑
                if (!Facade.HasMediator(NewRoleViewMediator.NAME))
                {
                    Facade.RegisterMediator(new NewRoleViewMediator());
                }

                NewRoleViewMediator roleViewMediator = Facade.RetrieveMediator(NewRoleViewMediator.NAME) as NewRoleViewMediator;

                if (roleViewMediator.ViewComponent == null)
                {
                    GameObject rolePanelAssets = Resources.Load<GameObject>("UI/RolePanel");
                    GameObject rolePanel = GameObject.Instantiate(rolePanelAssets, GameObject.Find("Canvas").transform);
                    //roleViewMediator.ViewComponent = rolePanel.GetComponent<NewRoleView>();
                    roleViewMediator.SetView(rolePanel.GetComponent<NewRoleView>());
                }

                SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);
                break;
        }
    }

    
}
