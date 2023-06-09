using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ProcessController : MonoBehaviour
    {
        [SerializeField, Header("玩家物件")]
        private PlayerController _player;
        [SerializeField, Header("終點Y座標")]
        private float _targetY = 100;
        [SerializeField, Header("總遊玩時數(秒)")]
        private float totalTime = 90;
        [SerializeField, Header("基礎屬性")]
        private PlayerData baseData;
        private PlayerData data;

        private bool isStop = false;
        private bool isEnd = false;

        #region UI 相關
        [SerializeField, Header("選項UI控制器")]
        private OptionsUIController optionsUI;
        [SerializeField, Header("遊戲UI控制器")]
        private GameUIController gameUI;
        [SerializeField, Header("結局UI控制器")]
        private GameEndUIController gameEndUI;
        [SerializeField, Header("選單控制器")]
        private MenuUIController menuUI;
        #endregion

        #region 怪物相關
        [SerializeField, Header("怪物池控制器")]
        private EnemyPoolController enemyPool;
        [SerializeField, Header("怪物生成間隔")]
        private float enemyTime = 1f;
        /// <summary>
        /// 下次怪物生成時間
        /// </summary>
        [Range(0.05f, 90f)]
        private float nextEnemyTime = 0f;
        /// <summary>
        /// 怪物X座標
        /// </summary>
        private float[] enemyX = new float[] { -3f, -1.5f, 0f, 1.5f, 3f };
        #endregion
        private void Start()
        {
            data = Instantiate(baseData);
            EnterGameStart();

        }

        private void FixedUpdate()
        {
            if (!isStop)
            {

                PlayerMoveTo(new Vector3(Player.transform.position.x, TargetY, Player.transform.position.z));
                EnemyHandel();
            }
            else
            {
                nextEnemyTime += Time.deltaTime;
            }
            if(Player.transform.position.y == TargetY)
            {
                IsGamePause = true;
                EnterGameEnd();
            }
        }

        private void EnemyHandel()
        {
            if (nextEnemyTime < Time.fixedTime)
            {
                nextEnemyTime = Time.fixedTime + enemyTime;
                GameObject enmey = enemyPool.GetUnactiveEnemy();
                enmey.transform.position = new Vector3(enemyX[Random.Range(0, enemyX.Length)], Player.transform.position.y + 20, Player.transform.position.z);
            }
        }

        private float MoveSpeed { get { return TargetY / totalTime; } }

        /// <summary>
        /// 使玩家向前移動
        /// </summary>
        /// <param name="target"></param>
        public void PlayerMoveTo(Vector3 target)
        {
            Vector3 newPosition = Vector3.MoveTowards(Player.transform.position, target, MoveSpeed * Time.fixedDeltaTime);
            Player.transform.position = newPosition;
        }

        public void EnterGetOptions()
        {
            IsGamePause = true;
            optionsUI.Enabled = true;
        }

        public void EnterGamePause()
        {
            IsGamePause = true;
            menuUI.Enabled = true;
        }

        public void EnterGameEnd()
        {
            if (!isEnd)
            {
                IsGamePause = true;
                gameEndUI.Enabled = true;
                gameEndUI.ShowEnd(data);
                isEnd = true;
            }
        }

        public void EnterGameStart()
        {
            IsGamePause = false;
            gameEndUI.Enabled = false;
            menuUI.Enabled = false;
            optionsUI.Enabled = false;
        }

        private bool IsGamePause
        {
            set
            {
                Player.IsStop = value;
                enemyPool.IsStop = value;
                gameUI.Enabled = !value;
                isStop = value;
            }
        }

        public float TargetY { get => _targetY; }

        public PlayerController Player { get => _player; }

        public void UpdatePlayerEventData(EventData eventData)
        {
            if(data.dexterity < 30)
                data.dexterity += eventData.dexterity;
            if(data.intelligence < 30)
                data.intelligence += eventData.intelligence;
            if(data.lucky < 30)
                data.lucky += eventData.lucky;
            if(data.spirit < 30)
                data.spirit += eventData.spirit;
            if(data.vitality < 30)
                data.vitality += eventData.vitality;
            if(data.money < 30)
                data.money += eventData.money;
        }
    }
}