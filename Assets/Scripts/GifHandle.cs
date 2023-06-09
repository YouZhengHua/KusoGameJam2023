using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifHandle : MonoBehaviour
{
    [Header("圖庫"), SerializeField]
    private Sprite[] sprites;
    [Header("圖片持續時間"), SerializeField]
    private float changeInterval = 0.33f;
    [Header("是否暫停")]
    public bool isStop = false;
    private int nextIndex = 0;
    private float nextTime;

    private void FixedUpdate()
    {
        if (sprites.Length > 0 && !isStop && Time.time > nextTime) { // nothing if no textures
            nextIndex++;
            nextTime = Time.time + changeInterval;
            nextIndex %= sprites.Length;
            GetComponent<Image>().sprite = sprites[nextIndex];
        }
    }
    public bool IsStop { set => isStop = value; }
    public Sprite[] Sprites { set => sprites = value; }
    public float ChangeInterval { set => changeInterval = value; }
}
