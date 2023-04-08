using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField, Header("玩家物件")]
        private GameObject player;
        [SerializeField, Header("終點Y座標")]
        private float targetY = 100;
        [SerializeField, Header("總遊玩時數(秒)")]
        private float totalTime = 90;
        [SerializeField, Header("遊戲進度圖片")]
        private Image proressImage;

        #region UI 相關
        private OptionsUIController optionsUI;
        #endregion

        #region 攝影機相關
        [SerializeField, Header("攝影機Y座標")]
        private int cameraY = 6;
        [SerializeField, Header("攝影機終點Y座標")]
        private int maxCameraY = 104;
        [SerializeField, Header("攝影機X座標")]
        private int cameraX = 0;
        #endregion

        #region 怪物相關
        [SerializeField, Header("怪物池控制器")]
        private EnemyController enemyPool;
        [SerializeField, Header("怪物生成間隔")]
        private float enemyTime = 1f;
        /// <summary>
        /// 下次怪物生成時間
        /// </summary>
        private float nextEnemyTime = 0f;
        /// <summary>
        /// 怪物X座標
        /// </summary>
        private float[] enemyX = new float[] { -3f, -1.5f, 0f, 1.5f, 3f };
        #endregion

        private void Update()
        {
            Camera.main.transform.position = new Vector3(cameraX, Mathf.Min(player.transform.position.y + cameraY, maxCameraY), Camera.main.transform.position.z);
            EnemyHandel();
        }

        private void FixedUpdate()
        {
            PlayerMoveTo(new Vector3(player.transform.position.x, targetY, player.transform.position.z));
            UpdateProgressRate();
        }

        private void EnemyHandel()
        {
            if(nextEnemyTime < Time.time)
            {
                nextEnemyTime = Time.time + enemyTime;
                GameObject enmey = enemyPool.GetUnactiveEnemy();
                enmey.transform.position = new Vector3(enemyX[Random.Range(0, enemyX.Length)], player.transform.position.y + 20, player.transform.position.z);
            }
        }


        private float MoveSpeed { get { return targetY / totalTime; } }

        /// <summary>
        /// 使玩家向前移動
        /// </summary>
        /// <param name="target"></param>
        public void PlayerMoveTo(Vector3 target)
        {
            Vector3 newPosition = Vector3.MoveTowards(player.transform.position, target, MoveSpeed * Time.fixedDeltaTime);
            player.transform.position = newPosition;
        }

        /// <summary>
        /// 更新遊戲進度條
        /// </summary>
        private void UpdateProgressRate()
        {
            proressImage.fillAmount = player.transform.position.y / targetY;
        }
    }
}