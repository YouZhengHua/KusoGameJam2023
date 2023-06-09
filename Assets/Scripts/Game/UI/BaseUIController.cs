using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game
{
    public class BaseUIController : MonoBehaviour
    {
        [Header("UI Canvas"), SerializeField]
        protected Canvas canvas;
        [Header("流程控制器"), SerializeField]
        protected ProcessController processController;

        public virtual bool Enabled
        {
            set
            {
                canvas.enabled = value;
            }
        }
    }
}