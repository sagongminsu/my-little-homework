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
        // PlayerPrefs에서 저장된 이름을 불러와 출력
        string playerName = PlayerPrefs.GetString("PlayerName", "DefaultName");
        playerNameText.text = playerName;

        // 이름 텍스트에 더블클릭 이벤트를 추가 
        playerNameText.gameObject.AddComponent<EventTrigger>().triggers.Add(GetPointerClickTrigger(EventTriggerType.PointerClick, OnNameTextDoubleClick));

        // 입력 필드에 포커스를 주기 위해 이벤트 리스너 추가
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
            // 더블클릭 시에 편집 가능한 상태로 전환
            isEditing = true;
            nameInputField.gameObject.SetActive(true);
            nameInputField.text = playerNameText.text;
            nameInputField.Select();
            nameInputField.ActivateInputField();
        }
    }

    private void OnEndEdit(string newName)
    {
        // 편집이 끝나면 새 이름을 저장하고 UI 업데이트
        isEditing = false;
        PlayerPrefs.SetString("PlayerName", newName);
        playerNameText.text =newName;
        nameInputField.gameObject.SetActive(false);
    }

    void Update()
    {
        // Esc 키를 누르면 편집 모드 종료
        if (isEditing && Input.GetKeyDown(KeyCode.Escape))
        {
            isEditing = false;
            nameInputField.gameObject.SetActive(false);
        }
    }
}
