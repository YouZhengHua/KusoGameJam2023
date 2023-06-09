using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace Game
{
    public class OptionsUIController : BaseUIController
    {
        [Header("選項"), SerializeField]
        private List<OptionController> options;
        [SerializeField, Header("提示文字")]
        private TextMeshProUGUI tipText;

        private void Awake()
        {
            Debug.Log("Enter OptionsUIController Awake()");
            foreach (var option in options)
            {
                option.GetButton.onClick.AddListener(() => OptionOnClick(option.Data));
            }
            Debug.Log("End OptionsUIController Awake()");
        }

        private void OptionOnClick(EventData data)
        {
            Enabled = false;
            processController.EnterGameStart();
            processController.UpdatePlayerEventData(data);
        }

        public void ShowOptions(List<EventData> datas)
        {
            Enabled = true;
            for (int i = 0; i < options.Count; i++)
            {
                options[i].Data = datas[i];
            }
            processController.EnterGetOptions();
        }

        public override bool Enabled
        {
            set
            {
                base.Enabled = value;
                if (value)
                {
                    tipText.text = "選擇一個你想吸收的人生經歷";
                }
            }
        }
    }
}