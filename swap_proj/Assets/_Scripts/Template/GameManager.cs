/* 
* Copyright Wemade Play Co., Ltd. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@wemadeplay.com>
* @created 2022-04-08
* @desc GameManager
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace common
{
    public class GameManager : MonoBehaviour
    {
        static GameManager _instance;
        public static GameManager instance
        {
            get
            {
                return _instance;
            }
        }

        [SerializeField] public Camera camera;
        [SerializeField] public SmoothFollow smoothFollow;

        public bool init = false;

        Vector3 cameraOriginPos = Vector3.zero;
        Quaternion cameraOriginRotate = Quaternion.identity;

        private void Awake()
        {
            _instance = this;

            //Application.runInBackground = true;
            Application.targetFrameRate = 60;
            QualitySettings.asyncUploadTimeSlice = 4;
            QualitySettings.asyncUploadBufferSize = 16;
            QualitySettings.asyncUploadPersistentBuffer = true;
            SoundManager.instance.Init(this);

            Screen.SetResolution(1920, 1080, true);

            // 게임 화면이 자동으로 꺼지는 옵션 막기
            Screen.sleepTimeout = SleepTimeout.NeverSleep;


        }

        private void Start()
        {
            Init();
        }

        /// <summary>
        /// 초기화
        /// </summary>
        /// <returns></returns>
        public void Init()
        {
            if (!init)
            {
                init = true;
            }
        }
    }
}