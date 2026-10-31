using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UIManager.GetInstance().ShowPanel<MP_MainView>("MainPanel");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            UIManager.GetInstance().HidePanel("MainPanel");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerModel.Data.Clear();
        }
    }
}
