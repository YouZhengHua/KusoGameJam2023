using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameEndUIController : BaseUIController
    {
        [Header("�����Ϊ��T���ΰ}�C"), SerializeField]
        private Image[] hexs;

        [Header("�����Ϊ���r�}�C"), SerializeField]
        private TextMeshProUGUI[] texts;

        [Header("�ݩʭȳ̤j��"), SerializeField]
        private float attrMax;

        [Header("�T���Ω���̤j��"), SerializeField]
        private float imageMaxWidth;
        [Header("�T���ΰ��׳̤j��"), SerializeField]
        private float imageMaxHeight;

        [Header("������"), SerializeField]
        private Image endImage;

        [Header("�������D"), SerializeField]
        private TextMeshProUGUI title;

        [Header("�������"), SerializeField]
        private EndData[] ends;

        private float endImageWidthMax = 1830f;
        private float endImageHeightMax = 1280f;

        [Header("��^���s"), SerializeField]
        private Button back;

        private void Awake()
        {
            back.onClick.AddListener(BackButtonOnClick);
        }

        private void BackButtonOnClick()
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }

        public void ShowEnd(PlayerData playerData)
        {
            SetRank(playerData);
            CheckEnd(playerData);
        }

        private void SetRank(PlayerData playerData)
        {
            SetRect(0, playerData.money);
            SetRect(1, playerData.money);
            texts[0].text = playerData.money.ToString();

            SetRect(2, playerData.lucky);
            SetRect(3, playerData.lucky);
            texts[1].text = playerData.lucky.ToString();

            SetRect(4, playerData.vitality);
            SetRect(5, playerData.vitality);
            texts[2].text = playerData.vitality.ToString();

            SetRect(6, playerData.intelligence);
            SetRect(7, playerData.intelligence);
            texts[3].text = playerData.intelligence.ToString();

            SetRect(8, playerData.dexterity);
            SetRect(9, playerData.dexterity);
            texts[4].text = playerData.dexterity.ToString();

            SetRect(10, playerData.spirit);
            SetRect(11, playerData.spirit);
            texts[5].text = playerData.spirit.ToString();
        }

        private void CheckEnd(PlayerData playerData)
        {
            if (playerData.money == 30 && playerData.lucky == 30 && playerData.vitality == 30 && playerData.intelligence == 30 && playerData.dexterity == 30 && playerData.spirit == 30)
            {
                SetEndImage(ends[3]);
            }
            else if (playerData.money < 10 && playerData.lucky < 10 && playerData.vitality < 10 && playerData.intelligence < 10 && playerData.dexterity < 10 && playerData.spirit < 10)
            {
                SetEndImage(ends[1]);
            }
            else if (playerData.money == 30)
            {
                SetEndImage(ends[5]);
            }
            else if (playerData.lucky == 30)
            {
                SetEndImage(ends[4]);
            }
            else if (playerData.vitality == 30)
            {
                SetEndImage(ends[0]);
            }
            else if (playerData.intelligence == 30)
            {
                SetEndImage(ends[2]);
            }
            else if (playerData.dexterity == 30)
            {
                SetEndImage(ends[8]);
            }
            else if (playerData.spirit == 30)
            {
                SetEndImage(ends[6]);
            }
            else
            {
                SetEndImage(ends[7]);
            }
        }

        private void SetEndImage(EndData endData) {
            endImage.sprite = endData.sprites[0];
            GifHandle gifHandle = endImage.GetComponent<GifHandle>();
            gifHandle.Sprites = endData.sprites;
            gifHandle.ChangeInterval = endData.changeInterval;
            float width = endImageWidthMax;
            float height = endImageWidthMax / endData.rate;
            if(height > endImageHeightMax)
            {
                height = endImageHeightMax;
                width = endImageHeightMax * endData.rate;
            }
            endImage.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            title.text = endData.title;
        }
        
        public void SetRect(int index, int attr)
        {
            float width = imageMaxWidth * GetRate(attr);
            float height = imageMaxHeight * GetRate(attr);
            hexs[index].GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }

        public float GetRate(int attr)
        {
            return Mathf.Max(Mathf.Min(attr / attrMax, 1f), 0f);
        }
    }
}
