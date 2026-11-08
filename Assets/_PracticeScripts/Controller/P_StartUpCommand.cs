using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class P_StartUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        Debug.Log("启动！");

        // 注册数据代理
        if (!Facade.HasProxy(Practice_CounterProxy.NAME))
        {
            Facade.RegisterProxy(new Practice_CounterProxy());
        }


    }
}
