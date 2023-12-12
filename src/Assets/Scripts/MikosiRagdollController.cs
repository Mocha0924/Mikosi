using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikosiRagdollController : MonoBehaviour
{
    private Rigidbody[] rBody;
    private BoxCollider[] BoxCol;
    private MeshCollider[] MeshCol;
    private Animator animator;
    [SerializeField] private Rigidbody MikosiRig;
    [SerializeField] private BoxCollider MikosiBox;
    void Start()
    {
        
        animator = GetComponent<Animator>();
        rBody = GetComponentsInChildren<Rigidbody>();
        BoxCol = GetComponentsInChildren<BoxCollider>();
        MeshCol = GetComponentsInChildren<MeshCollider>();
        foreach (Rigidbody RB in rBody)
        {
            RB.isKinematic = true;
        }
        foreach (BoxCollider BC in BoxCol)
        {
            BC.enabled = false;
        }
        foreach(MeshCollider MC in MeshCol)
        {
            MC.enabled = false;
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
        foreach (MeshCollider MC in MeshCol)
        {
            MC.enabled = true;
        }
    }
    public void SetPhysics()
    {
        animator.enabled = false;
        MikosiRig.isKinematic = false;
        MikosiBox.enabled = true;
    }
}
