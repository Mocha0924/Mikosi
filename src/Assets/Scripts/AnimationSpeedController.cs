using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeedController : MonoBehaviour
{
   private MikoshiCollisionDetection mikosiCollision;
    [SerializeField] private Animator[] HumanAnimator;
    [SerializeField] private Animator MikoshiAnimator;
    private int ReColum = 0;

    void Start()
    {
        mikosiCollision = GetComponent<MikoshiCollisionDetection>();
    }
    // Update is called once per frame
    void Update()
    {
        int Colum = mikosiCollision.ColumnCount;
        if(Colum!=ReColum)
        {
            foreach (Animator Human in HumanAnimator)
            {
                Human.SetFloat("speed", 2 + (Colum * 0.4f+1));
            }
            MikoshiAnimator.SetFloat("speed", 1 + (Colum * 0.2f+1));
        }
     ReColum = Colum;
    }
}
