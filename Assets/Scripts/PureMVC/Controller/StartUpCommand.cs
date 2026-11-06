using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : SimpleCommand
{
    // 1. 继承SimpleCommand类
    // 2. 重写Execute()方法
    public override void Execute(INotification notification)
    {
        // 命令模式，外部如果发送了通知，就会执行这里面的逻辑
        // notification 中存储着 Name 和 Body 等重要信息
        base.Execute(notification);

        // 开始时，需要注册 数据的代理 并初始化数据
        if (!Facade.HasProxy(PlayerProxy.NAME))
        {
            Facade.RegisterProxy(new PlayerProxy());
        }
    }
}
