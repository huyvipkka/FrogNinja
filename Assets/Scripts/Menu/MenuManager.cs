using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] protected Image settingBar;
    public void PlayBtn()
    {
        Debug.Log("playgame");
    }

    public void SettingBtn()
    {
        settingBar.gameObject.SetActive(true);
    }

    public void SettingBarExit()
    {
        settingBar.gameObject.SetActive(false);
    }
}
