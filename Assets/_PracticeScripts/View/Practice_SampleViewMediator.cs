using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_SampleViewMediator : Mediator 
{
    public new const string NAME = "SampleViewMediator";

    public Practice_SampleViewMediator() : base(NAME)
    {
        
    }

    public void SetButton(Practice_SampleView view)
    {
        if(view != null)
        {
            view.btnCounterCLR.onClick.AddListener(() =>
            {
                SendNotification(Practice_Notification.CLEAR,Facade.RetrieveProxy(Practice_CounterProxy.NAME));
            });
            view.btnCounterPlusOne.onClick.AddListener(() =>
            {
                SendNotification(Practice_Notification.ADD_ONE, Facade.RetrieveProxy(Practice_CounterProxy.NAME));
            });
            view.btnCounterPow.onClick.AddListener(() => 
            {
                SendNotification(Practice_Notification.POWER, Facade.RetrieveProxy(Practice_CounterProxy.NAME));
            });
            view.btnCounterSubOne.onClick.AddListener(() =>
            {
                SendNotification(Practice_Notification.SUB_ONE, Facade.RetrieveProxy(Practice_CounterProxy.NAME));
            });
        }
    }

    public override string[] ListNotificationInterests()
    {
        return new string[]
        {
            Practice_Notification.UPDATE_COUNTER,
        };
    }

    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);

        switch (notification.Name)
        {
            case Practice_Notification.UPDATE_COUNTER:
                if (ViewComponent != null)
                {
                    (ViewComponent as Practice_SampleView).UpdateInfo(notification.Body as Practice_CounterData);
                }
                break;
        }
    }


}
