using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ShowPanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        string panelName = notification.Body as string;

        switch (panelName)
        {
            case Practice_SampleViewMediator.NAME:
                // 检查该面板是否注册,没有注册就注册面板的Mediator
                if (!Facade.HasMediator(Practice_SampleViewMediator.NAME))
                {
                    Facade.RegisterMediator(new Practice_SampleViewMediator());                   
                }

                Practice_SampleViewMediator mediator = Facade.RetrieveMediator(Practice_SampleViewMediator.NAME) as Practice_SampleViewMediator;

                // 如果 ViewComponent 为空，表明我们没有创建对应的面板并赋予其 View 组件
                if (mediator.ViewComponent == null)
                {
                    // 创建面板
                    GameObject panelAssets = Resources.Load<GameObject>("Practice/Practice_SamplePanel");
                    GameObject panel = GameObject.Instantiate<GameObject>(panelAssets, GameObject.Find("Canvas").transform, false);

                    mediator.ViewComponent = panel.GetComponent<Practice_SampleView>();
                    mediator.SetButton(mediator.ViewComponent as Practice_SampleView);
                }
                
                

                break;
        }
    }
}
