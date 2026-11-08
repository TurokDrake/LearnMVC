using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Main : MonoBehaviour
{
    private void Start()
    {
        // 启动
        Practice_Facade.GetInstance().StartUp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Practice_Facade.GetInstance().SendNotification(Practice_Notification.SHOW, Practice_SampleViewMediator.NAME);
        }
    }
}
