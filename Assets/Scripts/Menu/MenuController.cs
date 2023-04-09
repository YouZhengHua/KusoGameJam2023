using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField, Header("開始按鈕")]
        private Button start;
        [SerializeField, Header("結束按鈕")]
        private Button exit;
        [SerializeField, Header("製作團隊")]
        private Button teamButton;
        [SerializeField, Header("製作團隊圖片")]
        private Button teamImage;
        private void Awake()
        {
            start.onClick.AddListener(StartButtonOnClick);
            exit.onClick.AddListener(ExitButtonOnClick);
            teamButton.onClick.AddListener(ShowTeamImage);
            teamImage.onClick.AddListener(HideTeamImage);
            teamImage.gameObject.SetActive(false);
        }

        private void ShowTeamImage()
        {
            teamImage.gameObject.SetActive(true);
        }

        private void HideTeamImage()
        {
            print("hello");
            teamImage.gameObject.SetActive(false);
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