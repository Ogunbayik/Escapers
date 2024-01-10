using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private const string ANIMATOR_CHOSEN_HASH = "isChosen";
    private const string ANIMATOR_RUN_HASH = "isRun";

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SadIdleAnimation(bool isActive)
    {
        this.animator.SetBool(ANIMATOR_CHOSEN_HASH, isActive);
    }

    public void RunningAnimation(bool isRun)
    {
        this.animator.SetBool(ANIMATOR_RUN_HASH, isRun);
    }


}
