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
        // �ɸ��Ͱ� ���� �ִ� ������ �������� ���̸� ��� �繰�� �����մϴ�.
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;

        // Debug.DrawRay�� ����Ͽ� ���̸� Scene �信 �׸��ϴ�.
        Debug.DrawRay(ray.origin, ray.direction * interactionRange, Color.green);

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // ���̿� �ε��� ��ü�� ������ �����ɴϴ�.
            GameObject hitObject = hit.collider.gameObject;

            // ���⼭ hitObject�� ���� ó���� �߰��մϴ�.
            // ���� ���, hitObject�� ��ȣ �ۿ� ������ �繰�̸� Ư�� ������ �����մϴ�.
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