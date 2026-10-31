using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 测试
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainController.ShowPanel();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            MainController.HidePanel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerModel.Data.Clear();
        }
    }
}
