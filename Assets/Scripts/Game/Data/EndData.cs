using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Data/End")]
    public class EndData : ScriptableObject
    {
        [Header("結局圖")]
        public Sprite[] sprites;
        [Header("標題")]
        public string title;
        [Header("圖片持續時間")]
        public float changeInterval;
        [Header("長寬比")]
        public float rate;
    }
}