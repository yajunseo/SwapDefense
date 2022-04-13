/* 
* Copyright Wemade Play Co., Ltd. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@wemadeplay.com>
* @created 2022-04-08
* @desc BridgeManager
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace common
{
    public class BridgeManager : MonoBehaviour
    {
        [SerializeField] public string logoSceneName = "1_Logo";
        [SerializeField] public string gameSceneName = "2_Game";

        private void Awake()
        {
            int firstRun = PlayerPrefs.GetInt("FIRST_RUN", 0);
            if (firstRun == 0)
            {
                PlayerPrefs.SetInt("FIRST_RUN", 1);
                SceneManager.LoadScene(gameSceneName);
            }
            else
                SceneManager.LoadScene(logoSceneName);
        }
    }
}
