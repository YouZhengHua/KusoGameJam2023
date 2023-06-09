using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class OptionController : MonoBehaviour
    {
        private EventData _data;

        private Image _image;
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _content;
        private void Awake()
        {
            _image = gameObject.transform.GetChild(0).GetComponent<Image>();
            _title = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _content = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        }

        public Button GetButton { get { return gameObject.GetComponent<Button>(); } }

        public string Title { get { return _title.text; } }
        public Image Image { get { return _image; } }
        public string Content { get { return _content.text; } }
        public EventData Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                _image.sprite = Data.sprites[0];
                GifHandle gifHandle = _image.GetComponent<GifHandle>();
                gifHandle.Sprites = Data.sprites;
                gifHandle.ChangeInterval = Data.changeInterval;
                _title.text = Data.title;
                _content.text = Data.content;
            }
        }
    }
}