using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimationSpeedController : MonoBehaviour
{
    public Animator animator;
    public float newSpeed = 0.2f; // �����ϰ� ���� �ӵ�

    void Start()
    {
        //�ӵ��� ������ ��� Start() �޼��峪 �ٸ� ������ ������ ����
        if (animator != null)
        {
            animator.speed = newSpeed;
        }
    }
}
