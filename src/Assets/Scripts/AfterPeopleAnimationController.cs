using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPeopleAnimationController : MonoBehaviour
{
    private Animator animator;
    private MikoshiCollisionDetection mikosiCollision;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f, 1f));
        mikosiCollision = GameObject.Find("Player").GetComponent<MikoshiCollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        int Colum = mikosiCollision.ColumnCount;
        animator.SetFloat("Speed", 2 + (Colum * 0.2f + 1));
    }
}
