using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameUIController : BaseUIController
    {
        [Header("�߸��ʵe"), SerializeField]
        private GifHandle heartAnimator;
        [SerializeField, Header("�C���i�׹Ϥ�")]
        private Image proressImage;

        private void Update()
        {
            UpdateProgressRate();
        }

        /// <summary>
        /// ��s�C���i�ױ�
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
