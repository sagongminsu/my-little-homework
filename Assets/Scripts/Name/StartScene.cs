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

        // PlayerPrefs�� ����Ͽ� �̸��� ����
        PlayerPrefs.SetString("PlayerName", playerName);

        // MainScene���� ��ȯ
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}


