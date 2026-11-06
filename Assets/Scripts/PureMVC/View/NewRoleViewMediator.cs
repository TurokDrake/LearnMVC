using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色面板的 Mediator
/// </summary>
public class NewRoleViewMediator : Mediator
{
    public new static string NAME = "NewRoleViewMediator";

    public NewRoleViewMediator() : base(NAME)
    {

    }

    public void SetView(NewRoleView roleView)
    {
        ViewComponent = roleView;
        // 为关闭按钮绑定事件
        roleView.btnClose.onClick.AddListener(() =>
        {
            SendNotification(PureNotification.HIDE_PANEL, this);
        });
        roleView.btnLevUp.onClick.AddListener(() =>
        {
            SendNotification(PureNotification.LEV_UP);
        });
    }

    public override string[] ListNotificationInterests()
    {
        // 像事件需要传入方法名一样，这里传入需要监听的通知名
        return new string[]
        {
            PureNotification.UPDATE_PLAYER_INFO
        };
    }

    public override void HandleNotification(INotification notification)
    {
        // 在上面的 ListNotificationInterests()方法中监听了通知
        // 在本方法中则处理监听的通知
        switch (notification.Name)
        {
            case PureNotification.UPDATE_PLAYER_INFO:
                // 当执行这个通知中的逻辑时
                if(ViewComponent!=null)
                    (ViewComponent as NewRoleView).UpdateInfo(notification.Body as PlayerDataObj);
                break;
        }
    }
}
