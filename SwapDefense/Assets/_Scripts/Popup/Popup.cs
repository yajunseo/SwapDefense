/* 
* Copyright Wemade Play Co., Ltd. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@wemadeplay.com>
* @created 2022-04-08
* @desc Popup
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using common;

[PopupImportant("Popup", "Prefabs/Popup")] 
public class Popup : MonoBehaviour
{
    [SerializeField] public GameObject PopupAnimationBackground;

    // 애니메이션 없이 팝업 삭제
    public virtual void CloseBtnNow(string PopupName)
    {
        PopupManager.Instance.PopupDestroy(PopupName);
        Click();
    }

    // 애니메이션을 통한 팝업 삭제
    public virtual void CloseBtn(string PopupName)
    {
        PopupAnimationBackground.GetComponent<Animator>().Play("CloseAnimation");

        PopupManager.Instance.CurrentPopupState = PopupName;
        Click();
    }

    protected void Click()
    {
        SoundManager.instance.PlaySFX("Button");
    }
}