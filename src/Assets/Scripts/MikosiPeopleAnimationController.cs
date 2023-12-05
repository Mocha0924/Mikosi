using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikosiPeopleAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;  // アニメーターコンポーネント取得用
    [SerializeField] private MikosiAnomationController mikosianimationController;
    // Start is called before the first frame update
    void Start()
    {
        // アニメーターコンポーネント取得
        animator = GetComponent<Animator>();
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f, 1f));
    }
    private void Update()
    {
        if (this.transform.position.y > -0.35 && !animator.GetBool("Jump"))
        {
            animator.SetBool("Jump", true);
            if (mikosianimationController != null)
                mikosianimationController.Jump();
        }
            
        else if (this.transform.position.y <= -3.15 && animator.GetBool("Jump"))
        {
            animator.SetBool("Jump", false);
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f, 1f));
            if (mikosianimationController != null)
                mikosianimationController.JumpDown();

        }
          


    }
}
