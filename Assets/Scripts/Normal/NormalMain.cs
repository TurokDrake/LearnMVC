using UnityEngine;

public class NormalMain : MonoBehaviour
{
    private void Update()
    {
        // 测试，按下 M键显示；按下 N键隐藏
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainPanel.ShowPanel();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            MainPanel.HidePanel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            MainPanel.ClearAllInfo();
        }
    }
}
