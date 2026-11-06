using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        // 根据传入的 Mediator ，隐藏面板，Mediator 将存放在 notification.Body 中
        Mediator mediator = notification.Body as Mediator;

        // 倘若传入的 Mediator 不为空，且其已经存储了视图组件
        if (mediator != null && mediator.ViewComponent != null)
        {
            // ViewComponent 中也就是我们的 NewMainView 或者 NewRoleView
            // 这两者均继承了 MonoBehaviour 类
            // 删除面板
            GameObject.Destroy((mediator.ViewComponent as MonoBehaviour).gameObject);
            // 同时置为空
            mediator.ViewComponent = null;
        }
    }
}
