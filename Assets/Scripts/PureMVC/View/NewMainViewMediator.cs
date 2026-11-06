using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主视图的 Mediator
/// </summary>
public class NewMainViewMediator : Mediator
{
    // Mediator 的名字
    public new static string NAME = "NewMainViewMediator";

    // 构造函数
    // 父类 Mediator 的构造函数中执行的操作如下：
    // 1. 设置 Mediator 的名字
    // 2. 设置 ViewComponent 的内容，ViewComponent即视图组件，在这里就是UGUI中的Text、Button组件等
    public NewMainViewMediator() : base(NAME)
    {

    }

    /// <summary>
    /// 获取面板
    /// </summary>
    /// <param name="mainView"></param>
    public void SetView(NewMainView mainView)
    {
        // 建立起该 Mediator 与 View 间的联系，能够修改 view 上的控件
        ViewComponent = mainView;

        // 设置视图时，也为其按钮绑定事件
        mainView.btnRole.onClick.AddListener(() =>
        {
            // 排查问题
            // 1. 检查传入的 mainView 是否为空，但是传入的 mainView 却有值，已排除该问题；
            // 2. 找到问题了，场景中缺了一个 EventSystem
            // 发现这条代码并没有执行，那么问题就在 事件并没有真正的添加到按钮上
            SendNotification(PureNotification.SHOW_PANEL, "RolePanel");
        });

    }


    // 列出 Mediator 感兴趣的通知名称
    // 返回值是一个 string数组，里面就存放我们需要注意的通知名
    public override string[] ListNotificationInterests()
    {
        // 像事件需要传入方法名一样，这里传入需要监听的通知名
        return new string[]
        {
            PureNotification.UPDATE_PLAYER_INFO
        };
    }

    // Mediator 处理通知的逻辑
    // 传入一个 INotification 对象，这个对象中包含了名称（Name）和 相关的内容（也被称作主体，Body）
    // 在Implementation Idioms and Best Practices 中，关于该方法的使用，有提及最好使用switch条件判断语句来处理不同通知的逻辑
    public override void HandleNotification(INotification notification)
    {
        // 在上面的 ListNotificationInterests()方法中监听了通知
        // 在本方法中则处理监听的通知
        switch (notification.Name)
        {
            case PureNotification.UPDATE_PLAYER_INFO:
                // 当执行这个通知中的逻辑时，将更新主面板的数据
                if(ViewComponent!=null)
                    (ViewComponent as NewMainView).UpdateInfo(notification.Body as PlayerDataObj);
                break;
        }
    }
}
