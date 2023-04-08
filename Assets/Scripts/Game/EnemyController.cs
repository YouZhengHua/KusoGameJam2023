using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class EnemyController : MonoBehaviour
    {
        [Header("敵人陣列"), SerializeField]
        private GameObject[] enemyArray;
        [Header("敵人池大小"), SerializeField]
        private int poolSize = 100;
        private List<GameObject> enemyList;

        private void Awake()
        {
            enemyList = new List<GameObject>();
            for(int i = 0; i < poolSize; i++)
            {
                GameObject enemy = Instantiate<GameObject>(enemyArray[Random.Range(0, enemyArray.Length)]);
                enemy.SetActive(false);
                enemyList.Add(enemy);
            }
        }

        public GameObject GetUnactiveEnemy()
        {
            List<GameObject> unactiveList = enemyList.FindAll(col => !col.activeSelf);
            GameObject enemy = unactiveList[Random.Range(0, unactiveList.Count)];
            enemy.SetActive(true);
            return enemy;
        }
    }
}