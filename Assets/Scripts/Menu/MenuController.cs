using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField, Header("�}�l���s")]
        private Button start;
        [SerializeField, Header("�������s")]
        private Button exit;
        [SerializeField, Header("�s�@�ζ�")]
        private Button teamButton;
        [SerializeField, Header("�s�@�ζ��Ϥ�")]
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