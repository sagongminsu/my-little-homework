using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    public event System.Action<Vector2> OnMoveEvent;
    public event System.Action<Vector2> OnLookEvent;

    public float interactionRange = 0.7f;

    void Update()
    {
        HandleInteractionInput();
    }

    void HandleInteractionInput()
    {
        // 케릭터가 보고 있는 방향을 기준으로 레이를 쏘아 사물을 감지합니다.
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;

        // Debug.DrawRay를 사용하여 레이를 Scene 뷰에 그립니다.
        Debug.DrawRay(ray.origin, ray.direction * interactionRange, Color.green);

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // 레이에 부딪힌 객체의 정보를 가져옵니다.
            GameObject hitObject = hit.collider.gameObject;

            // 여기서 hitObject에 대한 처리를 추가합니다.
            // 예를 들어, hitObject가 상호 작용 가능한 사물이면 특정 동작을 수행합니다.
            // hitObject.GetComponent<InteractableObject>().Interact();
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}