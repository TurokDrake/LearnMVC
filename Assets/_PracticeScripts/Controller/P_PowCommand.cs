using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PowCommand : SimpleCommand   
{
    public override void Execute(INotification notification)
    {

        base.Execute(notification);
        Practice_CounterProxy proxy = notification.Body as Practice_CounterProxy;

        if (proxy != null)
        {
            proxy.Power();
            SendNotification(Practice_Notification.UPDATE_COUNTER,proxy.Data as Practice_CounterData);
        }
    }
    
}
