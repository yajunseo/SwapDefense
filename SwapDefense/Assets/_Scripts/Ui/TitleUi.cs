using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUi : MonoBehaviour
{
    [SerializeField] GameObject titleObj;
    [SerializeField] GameObject ingameObj;

    private void Awake()
    {
        titleObj.SetActive(true);
        ingameObj.SetActive(false);
    }

    #region 클릭 관련
    public void Click_Start()
    {
        titleObj.SetActive(false);
        ingameObj.SetActive(true);
    }

    public void Click_Unit()
    {
        
    }

    public void Click_Setting()
    {
        PopupManager.Instance.PopupCreate<PopupSetting>().init();
    }

    public void Click_Win()
    {
        titleObj.SetActive(true);
        ingameObj.SetActive(false);
    }
    public void Click_Lose()
    {
        titleObj.SetActive(true);
        ingameObj.SetActive(false);
    }
    #endregion
}
