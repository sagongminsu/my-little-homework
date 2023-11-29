using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainScene : MonoBehaviour
{
    public Text playerNameText;
    public InputField nameInputField;

    private bool isEditing = false;

    void Start()
    {
        // PlayerPrefs���� ����� �̸��� �ҷ��� ���
        string playerName = PlayerPrefs.GetString("PlayerName", "DefaultName");
        playerNameText.text = playerName;

        // �̸� �ؽ�Ʈ�� ����Ŭ�� �̺�Ʈ�� �߰� 
        playerNameText.gameObject.AddComponent<EventTrigger>().triggers.Add(GetPointerClickTrigger(EventTriggerType.PointerClick, OnNameTextDoubleClick));

        // �Է� �ʵ忡 ��Ŀ���� �ֱ� ���� �̺�Ʈ ������ �߰�
        nameInputField.onEndEdit.AddListener(OnEndEdit);
    }

    private EventTrigger.Entry GetPointerClickTrigger(EventTriggerType type, UnityEngine.Events.UnityAction<BaseEventData> callback)
    {
        var entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(callback);
        return entry;
    }

    private void OnNameTextDoubleClick(BaseEventData eventData)
    {
        if (eventData is PointerEventData pointerEventData && pointerEventData.clickCount == 2)
        {
            // ����Ŭ�� �ÿ� ���� ������ ���·� ��ȯ
            isEditing = true;
            nameInputField.gameObject.SetActive(true);
            nameInputField.text = playerNameText.text;
            nameInputField.Select();
            nameInputField.ActivateInputField();
        }
    }

    private void OnEndEdit(string newName)
    {
        // ������ ������ �� �̸��� �����ϰ� UI ������Ʈ
        isEditing = false;
        PlayerPrefs.SetString("PlayerName", newName);
        playerNameText.text =newName;
        nameInputField.gameObject.SetActive(false);
    }

    void Update()
    {
        // Esc Ű�� ������ ���� ��� ����
        if (isEditing && Input.GetKeyDown(KeyCode.Escape))
        {
            isEditing = false;
            nameInputField.gameObject.SetActive(false);
        }
    }
}
