using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using common;

[PopupImportant("PopupSetting", "Prefabs/PopupSetting")] 
public class PopupSetting : Popup
{
    [SerializeField] Toggle sfx;
    [SerializeField] Toggle vibration;
    [SerializeField] Toggle bgm;
    [SerializeField] Text userID;

    public void init()
    {
        Initialize();
    }

    private void Initialize()
    {
        sfx.onValueChanged.AddListener((value) =>{
            Click_SFX(value);
        });

        vibration.onValueChanged.AddListener((value) =>{
            Click_Vibration(value);
        });

        bgm.onValueChanged.AddListener((value) =>{
            Click_BGM(value);
        });

        SoundManager.instance.SetMuteState(false, sfx.isOn = (PlayerPrefs.GetInt("MuteSFX") == 1 ? true : false));
        SoundManager.instance.SetMuteState(true, bgm.isOn = (PlayerPrefs.GetInt("MuteBGM") == 1 ? true : false));
        vibration.isOn = (PlayerPrefs.GetInt("MuteVib") == 1 ? true : false); 
    }

#region 클릭 관련
    public void Click_SFX(bool value)
    {
        PlayerPrefs.SetInt("MuteSFX", value == true ? 1 : 0);
        SoundManager.instance.SetMuteState(false, sfx.isOn = (PlayerPrefs.GetInt("MuteSFX") == 1 ? true : false));
    }

    public void Click_Vibration(bool value)
    {
        PlayerPrefs.SetInt("MuteVib", value == true ? 1 : 0);
    }

    public void Click_BGM(bool value)
    {
        PlayerPrefs.SetInt("MuteBGM", value == true ? 1 : 0);
        SoundManager.instance.SetMuteState(true, bgm.isOn = (PlayerPrefs.GetInt("MuteBGM") == 1 ? true : false));
    }

    public void Click_Policy()
    {
        Application.OpenURL("https://playtoz.com/privacy.html");
    }
#endregion
}