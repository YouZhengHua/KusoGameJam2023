using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        [Header("富爸媽"), Range(0, 30)]
        public int money;
        [Header("強運"), Range(0, 30)]
        public int lucky;
        [Header("體能"), Range(0, 30)]
        public int vitality;
        [Header("智慧"), Range(0, 30)]
        public int intelligence;
        [Header("才藝"), Range(0, 30)]
        public int dexterity;
        [Header("魅力"), Range(0, 30)]
        public int spirit;
    }
}