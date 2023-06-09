using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField, Header("玩家物件")]
        private PlayerController player;
        [SerializeField, Header("攝影機Y座標")]
        private int cameraY = 6;
        [SerializeField, Header("攝影機終點Y座標")]
        private int maxCameraY = 898;
        [SerializeField, Header("攝影機X座標")]
        private int cameraX = 0;

        private void Update()
        {
            Camera.main.transform.position = new Vector3(cameraX, Mathf.Min(player.transform.position.y + cameraY, maxCameraY), Camera.main.transform.position.z);
        }
    }
}