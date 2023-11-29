using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimationSpeedController : MonoBehaviour
{
    public Animator animator;
    public float newSpeed = 0.2f; // 조절하고 싶은 속도

    void Start()
    {
        //속도를 조절할 경우 Start() 메서드나 다른 적절한 곳에서 설정
        if (animator != null)
        {
            animator.speed = newSpeed;
        }
    }
}
