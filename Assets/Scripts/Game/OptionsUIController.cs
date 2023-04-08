using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class OptionsUIController : MonoBehaviour
    {
        [Header("UI Canvas"), SerializeField]
        private Canvas container;

        private void Awake()
        {
            container.enabled = false;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && container.enabled == true)
            {
                container.enabled = false;
                Time.timeScale = 1;
            }
        }

        public  void ShowOptions()
        {
            container.enabled = true;
            Time.timeScale = 0;
        }
    }
}