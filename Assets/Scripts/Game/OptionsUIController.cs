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
        [Header("選項1"), SerializeField]
        private OptionController option1;
        [Header("選項2"), SerializeField]
        private OptionController option2;
        [Header("選項3"), SerializeField]
        private OptionController option3;

        private void Awake()
        {
            container.enabled = false;
        }

        private void OptionOnClick()
        {

        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && container.enabled == true)
            {
                Vector3 mousePostion = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                CheckMousePostionOnOption(option1);
                CheckMousePostionOnOption(option2);
                CheckMousePostionOnOption(option3);
            }
        }

        public void ShowOptions(EventData[] options)
        {
            container.enabled = true;
            Time.timeScale = 0;
        }

        private void UpdateOption(Button option, EventData content)
        {

        }

        private bool CheckMousePostionOnOption(OptionController option)
        {
            Vector3 mousePostion = Input.mousePosition;
            RectTransform rect = (RectTransform)option.transform;
            float maxHeigth = rect.position.y + rect.rect.height / 2;
            float minHeigth = rect.position.y - rect.rect.height / 2;
            float maxWidth = rect.position.x + rect.rect.width / 2;
            float minWidth = rect.position.x - rect.rect.width / 2;
            bool result = mousePostion.x >= minWidth && mousePostion.x <= maxWidth && mousePostion.y >= minHeigth && mousePostion.y <= maxHeigth;
            return result;
        }
    }
}