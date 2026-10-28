using UnityEngine;
using UnityEngine.UI;

// 本脚本是不使用MVC框架的示例，只作简单示范，目的是为了传达MVC框架的思想
// 不使用MVC框架，一般的流程都是1. 获取控件；2. 加事件；3. 更新面板
public class MainPanel : MonoBehaviour
{
    // 1.获得控件
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtPower;
    public Text txtGem;

    public Button btnRole;

    public static MainPanel INSTANCE; // 具体的实例

    private void Start()
    {
        btnRole.onClick.AddListener(() =>
        {
            // 点击 btnRole 触发的事件
            RolePanel.ShowPanel();
        });
    }

    // 更新面板上的信息
    void UpdateInfo()
    {
        txtName.text = PlayerPrefs.GetString("PlayerName", "Turok");
        txtLev.text = "LV." + PlayerPrefs.GetInt("PlayerLevel", 1).ToString();

        txtMoney.text = PlayerPrefs.GetInt("PlayerMoney", 99).ToString();
        txtGem.text = PlayerPrefs.GetInt("PlayerGem", 999).ToString();
        txtPower.text = PlayerPrefs.GetInt("PlayerPower", 100).ToString();
    }

    public static void ShowPanel()
    {
        if (INSTANCE == null)
        {
            GameObject mainPanelAssets = Resources.Load<GameObject>("UI/MainPanel");
            GameObject mainPanel = Instantiate(mainPanelAssets, GameObject.Find("Canvas").transform);
            INSTANCE = mainPanel.GetComponent<MainPanel>();
        }
        INSTANCE.gameObject.SetActive(true);
        INSTANCE.UpdateInfo();
    }
    public static void HidePanel()
    {
        if (INSTANCE != null)
        {
            //Destroy(INSTANCE.gameObject);
            //INSTANCE = null;
            INSTANCE.gameObject.SetActive(false);
        }
    }

    // 测试使用
    public static void ClearAllInfo()
    {
        PlayerPrefs.SetInt("PlayerLevel", 1);
        PlayerPrefs.SetInt("PlayerHp", 10);
        PlayerPrefs.SetInt("PlayerAtk", 10);
        PlayerPrefs.SetInt("PlayerDef", 5);
        PlayerPrefs.SetInt("PlayerLuck", 5);
        PlayerPrefs.SetInt("PlayerCrit", 8);
        PlayerPrefs.SetInt("PlayerMiss", 15);
        RolePanel.ShowPanel();
        ShowPanel();
    }
}
