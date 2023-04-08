using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField, Header("¶}©l«ö¶s")]
        private Button start;
        [SerializeField, Header("µ²§ô«ö¶s")]
        private Button exit;
        private void Awake()
        {
            start.onClick.AddListener(StartButtonOnClick);
            exit.onClick.AddListener(ExitButtonOnClick);
        }

        private void StartButtonOnClick()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        private void ExitButtonOnClick()
        {
            Application.Quit();
        }
    }
}