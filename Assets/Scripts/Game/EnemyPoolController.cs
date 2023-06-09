using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class EnemyPoolController : MonoBehaviour
    {
        [Header("敵人"), SerializeField]
        private GameObject enemyPrefab;
        [Header("敵人池大小"), SerializeField]
        private int poolSize = 100;
        private List<GameObject> enemyList;

        private void Awake()
        {
            Debug.Log("Enter EnemyPoolController Awake()");
            enemyList = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject enemy = CreateEmeny();
                enemy.SetActive(false);
                enemyList.Add(enemy);
            }
            Debug.Log("EnemyPoolController Awake() Exit");
        }

        private void Update()
        {
            
        }

        private GameObject CreateEmeny()
        {
            return Instantiate<GameObject>(enemyPrefab);
        }

        public GameObject GetUnactiveEnemy()
        {
            List<GameObject> unactiveList = enemyList.FindAll(col => col.activeSelf == false);
            GameObject enemy;
            if (unactiveList.Count == 0)
            {
                enemy = CreateEmeny();
                enemyList.Add(enemy);
            }
            else
            {
                int index = Random.Range(0, unactiveList.Count);
                enemy = unactiveList[index];
            }
            enemy.SetActive(true);
            return enemy;
        }

        public bool IsStop
        {
            set
            {
                List<GameObject> activeList = enemyList.FindAll(col => col.activeSelf);
                foreach(GameObject enemy in activeList)
                {
                    Animator animator = enemy.GetComponent<Animator>();
                    if (value)
                    {
                        animator.enabled = false;
                    }
                    else
                    {
                        animator.enabled = true;
                    }
                }
            }
        }
    }
}