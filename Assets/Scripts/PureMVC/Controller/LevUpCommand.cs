using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        // 得到 PlayerProxy， 使用其中的 LevUp() 方法
        PlayerProxy tempPlayerProxy = Facade.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;
        if (tempPlayerProxy != null)
        {
            tempPlayerProxy.LevUp();
            SendNotification(PureNotification.UPDATE_PLAYER_INFO, tempPlayerProxy.Data);
        }
    }
}
