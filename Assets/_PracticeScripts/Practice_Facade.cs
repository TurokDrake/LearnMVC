using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_Facade :Facade    
{
    public static Practice_Facade GetInstance()
    {
        if (instance == null)
        {
            instance = new Practice_Facade();
        }

        return instance as Practice_Facade;
    }

    protected override void InitializeController()
    {
        base.InitializeController();

        RegisterCommand(Practice_Notification.SHOW, () =>
        {
            return new P_ShowPanelCommand();
        });

        RegisterCommand(Practice_Notification.STARTUP, () =>
        {
            return new P_StartUpCommand();
        });

        RegisterCommand(Practice_Notification.ADD_ONE, () =>
        {
            return new P_PlusOneCommand();
        });

        RegisterCommand(Practice_Notification.CLEAR, () =>
        {
            return new P_CLRCommand();
        });

        RegisterCommand(Practice_Notification.SUB_ONE, () =>
        {
            return new P_SubOneCommand();
        });

        RegisterCommand(Practice_Notification.POWER, () =>
        {
            return new P_PowCommand();
        });
    }

    public void StartUp()
    {
        SendNotification(Practice_Notification.STARTUP);
    }

}
