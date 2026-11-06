using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局唯一的 Facade，它管理着 Proxy、Mediator 和 Command
/// </summary>
public class GameFacade : Facade
{
    // 1. 继承Facade类
    // 2. 手动实现一个单例
    public static GameFacade Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameFacade();
            }
            // instance 是 IFacade 类型的，因此为了使用 我们这个GameFacade，需要转换
            return instance as GameFacade;
        }
    }

    // 3. InitializeController() 初始化Controller
    protected override void InitializeController()
    {
        base.InitializeController();

        // 注册命令 Command
        // 以后发送 START_UP 通知，就会执行 这个 Lambda表达式的逻辑
        RegisterCommand(PureNotification.START_UP, () =>
        {
            return new StartUpCommand();
        });

        // 注册 SHOW_PANEL 通知
        RegisterCommand(PureNotification.SHOW_PANEL, () =>
        {
            return new ShowPanelCommand();
        });

        RegisterCommand(PureNotification.HIDE_PANEL, () =>
        {
            return new HidePanelCommand();
        });

        RegisterCommand(PureNotification.LEV_UP, () =>
        {
            return new LevUpCommand();
        });
    }

    // 4. 需要有一个启动函数供外部使用，这个函数内部就执行发送通知的逻辑
    public void StartUp()
    {
        // 执行了 StartUp()方法后，就会发送 START_UP 通知，就会执行 StartUpCommand 的逻辑
        SendNotification(PureNotification.START_UP);
    }
}
