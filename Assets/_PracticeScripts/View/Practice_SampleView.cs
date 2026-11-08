using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Sample 视图
/// </summary>
public class Practice_SampleView : MonoBehaviour
{
    public Text txtCounter;
    public Text txtCounterPow;

    public Button btnOpenNewWindow;
    public Button btnCounterPlusOne;
    public Button btnCounterCLR;
    public Button btnCounterSubOne;
    public Button btnCounterPow;

    public void UpdateInfo(Practice_CounterData data)
    {
        if(data == null)
        {
            Debug.Log("counterData = null");
            return;
        }
        txtCounter.text = txtCounter.text.Substring(0, 8) + data.num;
        txtCounterPow.text = txtCounterPow.text.Substring(0, 6) + data.powerOfNum;
    }

}
