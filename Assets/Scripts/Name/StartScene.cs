using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public InputField nameInputField;

    public void StartGame()
    {
        string playerName = nameInputField.text;

        // PlayerPrefs를 사용하여 이름을 저장
        PlayerPrefs.SetString("PlayerName", playerName);

        // MainScene으로 전환
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}


