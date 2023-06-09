using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [CreateAssetMenu(menuName = "Data/Event")]
    public class EventData : ScriptableObject
    {
        [Header("富爸媽")]
        public int money;
        [Header("強運")]
        public int lucky;
        [Header("體能")]
        public int vitality;
        [Header("智慧")]
        public int intelligence;
        [Header("魅力")]
        public int spirit;
        [Header("才藝")]
        public int dexterity;
        [Header("標題")]
        public string title;
        [Header("內容")]
        public string content;
        [Header("圖庫"), SerializeField]
        public Sprite[] sprites;
        [Header("圖片持續時間"), SerializeField]
        public float changeInterval = 0.33f;
    }
}