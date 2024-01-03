using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikosiAnimationController : MonoBehaviour
{
    public bool JumpCheck = false;
    private bool LeftGetCheck = true;
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
        JumpCheck = true;
    }
    public void JumpDown()
    {
        JumpCheck = false;
        animator.SetBool("Jump", false);
        animator.SetTrigger("JumpDown");
        
    }
    public void LeftTurn()
    {
        animator.SetBool("LeftTurn", true);
    }
    public void FinishLeftTurn()
    {
        animator.SetBool("LeftTurn", false);
    }
    public void RightTurn()
    {
        animator.SetBool("RightTurn", true);
    }
    public void FinishRightTurn()
    {
        animator.SetBool("RightTurn", false);
    }
    public void GetPeople()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MikosiNormal")||animator.GetBool("LeftGet")|| animator.GetBool("RightGet"))
        {
            if(transform.rotation.z < 0|| animator.GetBool("RightGet"))
            {
                animator.SetTrigger("LeftGet");
                animator.ResetTrigger("RightGet");
            }
            else if(transform.rotation.z > 0|| animator.GetBool("LeftGet"))
            {
                animator.SetTrigger("RightGet");
                animator.ResetTrigger("LeftGet");
            }

           

        }
      
    }
}
