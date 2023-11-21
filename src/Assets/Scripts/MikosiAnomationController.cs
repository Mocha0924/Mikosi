using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikosiAnomationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
  
    public void Jump()
    {
        animator.SetBool("Jump", true);
    }
    public void JumpDown()
    {
        animator.SetBool("Jump", false);
        animator.SetTrigger("JumpDown");
    }
}
