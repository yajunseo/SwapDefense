/* 
* Copyright (C) SundayToz Corp. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@sundaytoz.com>
* @created 2021/12/10
* @desc PopupAnimationController
*/
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;

public class PopupAnimationController : MonoBehaviour
{
    private void Start() {
        //if(PopupManager.Instance.CurrentPopupState.Equals("PopupSetting")) this.GetComponent<Animator>().Play("OpenAnimation"); 
    }

    public void OnAnimationStart()
    {
        //SoundManager.Instance.PlaySfxSound("popup");
    }

    public void OnAnimationEnd()
    {
        PopupManager.Instance.PopupDestroy(PopupManager.Instance.CurrentPopupState);
    }
}
