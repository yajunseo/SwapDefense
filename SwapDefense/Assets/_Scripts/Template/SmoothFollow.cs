/* 
* Copyright Wemade Play Co., Ltd. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@wemadeplay.com>
* @created 2022-04-08
* @desc SmoothFollow
*/
using UnityEngine;

namespace common
{
    public class SmoothFollow : MonoBehaviour
    {
        #region Consts
        public const float SMOOTH_TIME = 0.3f;
        #endregion

        #region Public Properties
        public bool LockX;
        public bool LockY;
        public bool LockZ;
        public float positionX = 0f;
        public float positionY = 0f;
        public float positionZ = 0f;
        public bool useSmoothing;
        #endregion

        #region Private Properties
        private Transform thisTransform;
        private Vector3 velocity;
        #endregion

        [SerializeField]
        public Camera camera;

        float height = 0f;

        GameManager manager;
        public GameObject targetObject;
        public float targetSize;

        Vector3 targetOriginPos = Vector3.zero;

        private void Awake()
        {
            thisTransform = transform;
            //velocity = new Vector3(1f, 1f, 1f);
            velocity = new Vector3(0.5f, 0.5f, 0.5f);
        }

        public void Init(GameManager manager)
        {
            this.transform.localPosition = Vector3.zero;
            positionX = 0.7f;

            this.manager = manager;

            //targetObject = manager.smartPhone.gameObject;
            //targetOriginPos = manager.smartPhone.transform.position;
        }

        // ReSharper disable UnusedMember.Local
        private void FixedUpdate()
        {
            if (targetObject == null)
                return;

            //if (manager.state == GameState.NONE || manager.state == GameState.READY)
            //    return;

            //if (manager.state != GameState.PLAY)
            //    return;

            Vector3 newPos = Vector3.zero;

            if (useSmoothing)
            {
                newPos.x = Mathf.SmoothDamp(thisTransform.position.x, targetObject.transform.position.x + positionX, ref velocity.x, SMOOTH_TIME);
                //newPos.y = Mathf.SmoothDamp(thisTransform.position.y, targetObject.transform.position.y + positionY - targetOriginPos.y, ref velocity.y, SMOOTH_TIME);
                newPos.z = Mathf.SmoothDamp(thisTransform.position.z, targetObject.transform.position.z + positionZ, ref velocity.z, SMOOTH_TIME);
            }
            else
            {
                newPos.x = targetObject.transform.position.x + positionX;
                //newPos.y = targetObject.transform.position.y + positionY - targetOriginPos.y;
                newPos.z = targetObject.transform.position.z + positionZ;
            }

            #region Locks
            if (LockX)
            {
                newPos.x = thisTransform.position.x + positionX;
            }

            if (LockY)
            {
                newPos.y = targetObject.transform.position.y + positionY - targetOriginPos.y;
            }

            if (LockZ)
            {
                newPos.z = thisTransform.position.z;
            }
            #endregion

            //if (newPos.y < 0f)
            //    newPos.y = 0f;

            //camera.fieldOfView = Mathf.Clamp(50f + (newPos.y * 0.05f), 50f, 80f);
            //camera.orthographicSize = Mathf.Clamp(6.0f + (newPos.y * 0.05f), 6.0f, 10f);

            if (manager != null)
            {
                //if (targetSize > camera.orthographicSize)
                //    camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, targetSize, ref velocity.x, SMOOTH_TIME);

                //if (manager.stackCount - 1 > 3)
                //{
                //    float size = 6.4f + ((float)(manager.stackCount - 3) / 10f);
                //    camera.orthographicSize = Mathf.Clamp(size, 6.4f, 10f);
                //}
            }

            transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
        }
    }
}