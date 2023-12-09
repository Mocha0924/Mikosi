using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigdollController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody[] rBody;
    private BoxCollider[] BoxCol;
    private CapsuleCollider[] CapsuleCol; 
    private SphereCollider[] SphereCol;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponentsInChildren<Rigidbody>();
        BoxCol = GetComponentsInChildren<BoxCollider>();
        CapsuleCol = GetComponentsInChildren<CapsuleCollider>();
        SphereCol = GetComponentsInChildren<SphereCollider>();
        foreach (Rigidbody RB in rBody)
        {
            RB.isKinematic = true;
        }
        foreach(BoxCollider BC in BoxCol)
        {
            BC.enabled = false;
        }
        foreach (CapsuleCollider CC in CapsuleCol)
        {
            CC.enabled = false;
        }
        foreach(SphereCollider SC in SphereCol)
        {
            SC.enabled = false; 
        }
    }
   
    
    public void SetRagDoll()
    {
        animator.enabled = false;
        foreach (Rigidbody RB in rBody)
        {
            RB.isKinematic = false;
        }
        foreach (BoxCollider BC in BoxCol)
        {
            BC.enabled = true;
        }
        foreach (CapsuleCollider CC in CapsuleCol)
        {
            CC.enabled = true;
        }
        foreach (SphereCollider SC in SphereCol)
        {
            SC.enabled = true;
        }
    }
    
}
