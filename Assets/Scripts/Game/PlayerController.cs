using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [Header("玩家資料"), SerializeField]
        private PlayerData data;

        [Header("每次移動距離"), SerializeField]
        private float moveDistance = 1.5f;

        [Header("升級選項UI"), SerializeField]
        private OptionsUIController optionsUI;

        private void Awake()
        {
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject enemy = collision.gameObject;
            if(enemy.layer == LayerMask.NameToLayer("Enemy"))
            {
                enemy.SetActive(false);
                EventData[] events = new EventData[] { new EventData(), new EventData(), new EventData() };
                optionsUI.ShowOptions(events);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
            {
                float nextX = transform.position.x + moveDistance < rightLimit ? transform.position.x + moveDistance : rightLimit;
                this.transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
            {
                float nextX = transform.position.x - moveDistance > leftLimit ? transform.position.x - moveDistance : leftLimit;
                this.transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
            }
        }

        /// <summary>
        /// 左邊座標邊際
        /// </summary>
        private float leftLimit { get { return 0 - (moveDistance * 2); } }
        /// <summary>
        /// 右邊座標邊際
        /// </summary>
        private float rightLimit { get { return 0 + (moveDistance * 2); } }
    }
}