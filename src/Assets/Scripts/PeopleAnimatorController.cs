using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAnimatorController : MonoBehaviour
{
    private Animator PeopleAnimator;
    [SerializeField] private bool Rand;
    [SerializeField] private int AnimationNum;
    // Start is called before the first frame update
    void Start()
    {
        PeopleAnimator = GetComponent<Animator>();
        if(Rand)
        {
            int Randnum = UnityEngine.Random.Range(1,5);
            PeopleAnimator.SetBool("Case"+Randnum,true);
        }
        else if(AnimationNum > 0&&AnimationNum<5)
            PeopleAnimator.SetBool("Case" +AnimationNum, true);
    }

   
}
