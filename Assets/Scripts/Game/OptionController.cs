using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class OptionController : MonoBehaviour
    {
        [SerializeField, Header("事件屬性")]
        private EventData baseData;
        [SerializeField, Header("按鈕")]
        private EventData showData;

        private Image title;
        private Image image;
        private Image content;
        private void Awake()
        {
            showData = EventData.Instantiate(baseData);
            image = gameObject.transform.GetChild(1).GetComponent<Image>();
            title = gameObject.transform.GetChild(2).GetComponent<Image>();
            content =gameObject.transform.GetChild(3).GetComponent<Image>();
        }
    }
}