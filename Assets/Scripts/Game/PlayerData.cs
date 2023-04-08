using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        [Header("移動速度")]
        public int MoveSpeed = 100;
    }
}