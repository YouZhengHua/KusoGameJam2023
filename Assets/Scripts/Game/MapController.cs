using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MapController : MonoBehaviour
    {
        [Header("地圖陣列"), SerializeField]
        private GameObject[] mapArray;

        [Header("主角物件"), SerializeField]
        private GameObject player;

        private List<GameObject> mapList;

        [Header("循環高度"), SerializeField]
        private float loopHeight = 21;

        private void Awake()
        {
            mapList = new List<GameObject>();
            for (int i = 0; i < mapArray.Length; i++)
            {
                GameObject map = mapArray[i];
                GameObject tmp = Instantiate<GameObject>(map);
                tmp.SetActive(false);
                mapList.Add(tmp);
            }

            for(int i = 0;  i < 3; i++)
            {
                Vector3 location = new Vector3(0, 0 + (loopHeight * i), 0);
                GameObject map = GetUnactiveMap();
                map.SetActive(true);
                map.transform.position = location;
            }
        }

        private void Update()
        {
            foreach (GameObject map in mapList.FindAll(col => col.activeSelf))
            {
                UpdateMapLocation(map);
            }
        }

        private void UpdateMapLocation(GameObject map)
        {
            if (player.transform.position.y - map.transform.position.y > loopHeight * 0.8)
            {
                map.SetActive(false);

                GameObject nextMap = GetUnactiveMap();
                float nextY = (Mathf.CeilToInt(player.transform.position.y / loopHeight) + 2) * loopHeight;
                Vector3 newLocation = new Vector3(map.transform.position.x, nextY, map.transform.position.z);
                nextMap.transform.position = newLocation;
            }
        }

        private GameObject GetUnactiveMap()
        {
            List<GameObject> unactiveMaps = mapList.FindAll(col => !col.activeSelf);
            GameObject map = unactiveMaps[Random.Range(0, unactiveMaps.Count)];
            map.SetActive(true);
            return map;
        }
    }
}