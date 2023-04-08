using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifHandle : MonoBehaviour
{
    [Header("�Ϯw"), SerializeField]
    private Sprite[] sprites;
    [Header("�Ϥ�����ɶ�"), SerializeField]
    private float changeInterval = 0.33f;

    void Update()
    {
        if (sprites.Length > 0) { // nothing if no textures
            // we want this texture index now
            int index = Mathf.FloorToInt(Time.time / changeInterval);
            // take a modulo with size so that animation repeats
            index = index % sprites.Length;
            // assign it
            GetComponent<Image>().sprite = sprites[index];
        }
    }
}
