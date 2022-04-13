/* 
* Copyright Wemade Play Co., Ltd. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@wemadeplay.com>
* @created 2022-04-08
* @desc LogoeManager
*/
using UnityEngine.SceneManagement;
using UnityEngine;

namespace common
{
    public class LogoManager : MonoBehaviour
    {
        [SerializeField] public string gameSceneName = "2_Game";
        [SerializeField] float changeTime = 2f;

        private void Start()
        {
            Invoke("ChangeScene", changeTime);
        }

        void ChangeScene()
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
