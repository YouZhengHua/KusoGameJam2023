using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class EnemyController : MonoBehaviour
    {
        [Header("事件清單"), SerializeField]
        private EventData[] allEvent;
        [Header("事件數量"), SerializeField]
        private int eventCount = 3;
        private List<EventData> events;
        private GameObject player;

        private void Start()
        {
            events = new List<EventData>();
            List<int> eventIndexs = new List<int>();
            for (int i = 0; i < eventCount; i++)
            {
                int index = Random.Range(0, allEvent.Length);
                while(eventIndexs.Contains(index) && eventCount >= eventIndexs.Count){
                    index = Random.Range(0, allEvent.Length);
                }
                eventIndexs.Add(index);
                EventData eventData = Instantiate(allEvent[index]);
                events.Add(eventData);
            }
            player = GameObject.Find("Player");
        }

        private void FixedUpdate()
        {
            if((gameObject.transform.position - player.transform.position).magnitude > 50){
                gameObject.SetActive(false);
            }
        }

        public List<EventData> Events { get => events; }
    }
}