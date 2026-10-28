using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour
{
    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrit;
    public Text txtMiss;
    public Text txtLuck;

    public Button btnClose;
    public Button btnLevUp;

    public static RolePanel INSTANCE;

    private void Start()
    {
        btnClose.onClick.AddListener(() =>
        {
            // 关闭面板
            HidePanel();
        });
        btnLevUp.onClick.AddListener(() =>
        {
            // 升级
            PlayerPrefs.SetInt("PlayerLevel", int.Parse(txtLev.text.Replace("LV.", "")) + 1);
            PlayerPrefs.SetInt("PlayerHp", int.Parse(txtHp.text) + 10);
            PlayerPrefs.SetInt("PlayerAtk", int.Parse(txtAtk.text) + 5);
            PlayerPrefs.SetInt("PlayerDef", int.Parse(txtDef.text) + 10);
            PlayerPrefs.SetInt("PlayerLuck", int.Parse(txtLuck.text) + 1);
            PlayerPrefs.SetInt("PlayerCrit", int.Parse(txtCrit.text) + 1);
            PlayerPrefs.SetInt("PlayerMiss", int.Parse(txtMiss.text) + 1);
            UpdateInfo();
            MainPanel.ShowPanel();
        });
    }

    void UpdateInfo()
    {
        txtLev.text = "LV." + PlayerPrefs.GetInt("PlayerLevel", 1).ToString();
        txtHp.text = PlayerPrefs.GetInt("PlayerHp", 10).ToString();
        txtAtk.text = PlayerPrefs.GetInt("PlayerAtk", 10).ToString();
        txtDef.text = PlayerPrefs.GetInt("PlayerDef", 5).ToString();
        txtLuck.text = PlayerPrefs.GetInt("PlayerLuck", 5).ToString();
        txtCrit.text = PlayerPrefs.GetInt("PlayerCrit", 8).ToString();
        txtMiss.text = PlayerPrefs.GetInt("PlayerMiss", 15).ToString();
    }

    public static void ShowPanel()
    {
        if (INSTANCE == null)
        {
            GameObject rolePanelAssets = Resources.Load<GameObject>("UI/RolePanel");
            GameObject rolePanel = Instantiate(rolePanelAssets, GameObject.Find("Canvas").transform);
            INSTANCE = rolePanel.GetComponent<RolePanel>();
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
}
