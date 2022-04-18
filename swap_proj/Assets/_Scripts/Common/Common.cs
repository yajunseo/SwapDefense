/* 
* Copyright Wemade Play Co., Ltd. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@wemadeplay.com>
* @created 2022-04-08
* @desc common
*/
using UnityEngine;
using System.Collections;

namespace common
{
    public class Common : MonoBehaviour
    {
        public static T CreateSingleton<T>(string name) where T : Component
        {
            T instance = GameObject.FindObjectOfType(typeof(T)) as T;

            if (instance == null)
            {
                GameObject obj = new GameObject(name);
                instance = obj.AddComponent<T>();
                DontDestroyOnLoad(instance);
            }

            return instance;
        }
    }
}