using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [Header("每次移動距離"), SerializeField]
        private float moveDistance = 1.5f;

        [Header("升級選項UI"), SerializeField]
        private OptionsUIController optionsUI;

        private bool _IsStop = false;

        private void Start()
        {
            IsStop = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
                enemy.gameObject.SetActive(false);
                optionsUI.ShowOptions(enemy.Events);
                IsStop = true;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                float nextX = transform.position.x + moveDistance < RightLimit ? transform.position.x + moveDistance : RightLimit;
                this.transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                float nextX = transform.position.x - moveDistance > LeftLimit ? transform.position.x - moveDistance : LeftLimit;
                this.transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
            }
        }

        /// <summary>
        /// 左邊座標邊際
        /// </summary>
        private float LeftLimit { get { return 0 - (moveDistance * 2); } }
        /// <summary>
        /// 右邊座標邊際
        /// </summary>
        private float RightLimit { get { return 0 + (moveDistance * 2); } }

        public bool IsStop
        {
            set
            {
                _IsStop = value;
                Animator animator = gameObject.GetComponent<Animator>();
                if (value)
                {
                    animator.enabled = false;
                }
                else
                {
                    animator.enabled = true;
                }
            }
        }
    }
}