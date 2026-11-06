using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 测试，使用 GameFacade 的实例发送通知
        GameFacade.Instance.StartUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameFacade.Instance.SendNotification(PureNotification.SHOW_PANEL, "MainPanel");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            GameFacade.Instance.SendNotification(PureNotification.HIDE_PANEL, GameFacade.Instance.RetrieveMediator("NewMainViewMediator"));
        }
    }
}
