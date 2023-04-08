using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameUIController : BaseUIController
    {
        [Header("心跳動畫"), SerializeField]
        private GifHandle heartAnimator;
        [SerializeField, Header("遊戲進度圖片")]
        private Image proressImage;

        private void Update()
        {
            UpdateProgressRate();
        }

        /// <summary>
        /// 更新遊戲進度條
        /// </summary>
        private void UpdateProgressRate()
        {
            proressImage.fillAmount = processController.Player.transform.position.y / processController.TargetY;
        }

        public override bool Enabled
        {
            set
            {
                heartAnimator.IsStop = !value;
            }
        }
    }
}
