using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PlusOneCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        Practice_CounterProxy proxy = notification.Body as Practice_CounterProxy;

        if (proxy != null)
        {
            proxy.AddOne();

            SendNotification(Practice_Notification.UPDATE_COUNTER, proxy.Data as Practice_CounterData);
        }
    }
}
