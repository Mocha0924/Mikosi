using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPeopleAnimationController : MonoBehaviour
{
    private Animator animator;
    private MikoshiCollisionDetection mikosiCollision;
    private bool TurnCheck = false;
    [SerializeField] private float MinChangeTime;
    [SerializeField] private float MaxChangeTime;
    private float RandomTime;
    private float NowTime = 0;
    private player Player;
    [SerializeField] private float BendSpeed;
    [SerializeField] private float ReturnSpeed;
    [SerializeField] private float MinRandSpeed;
    [SerializeField] private float MaxRandSpeed;
    private float RandSpeed = 1;
    private enum Direction
    { 
        front,
        right,
        left
    }
    private Direction direction = Direction.front;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f, 1f));
        mikosiCollision = GameObject.Find("Player").GetComponent<MikoshiCollisionDetection>();
        animator.SetInteger("Rand", Random.Range(0, 2));
        RandomTime = Random.Range(MinChangeTime, MaxChangeTime);
        Player = GameObject.Find("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.turn_complete_R)
        {
            if(!TurnCheck)
            {
                animator.SetBool("RightTurn",true);
                TurnCheck = true;
            }
                
        }
        else if(Player.turn_complete_L)
        {
            if (!TurnCheck)
            {
                animator.SetBool("LeftTurn", true);
                TurnCheck = true;
            }
        }
        else if(!Player.turn_complete_R&& !Player.turn_complete_L&&TurnCheck)
        {
            animator.SetBool("RightTurn", false);
            animator.SetBool("LeftTurn", false);
            TurnCheck = false;
        }
        else
        {
            int Colum = mikosiCollision.ColumnCount;
            animator.SetFloat("Speed", 2 + (Colum * 0.2f + 1));


            if (NowTime >= RandomTime)
            {
                animator.SetInteger("Rand", Random.Range(0, 2));
                RandomTime = Random.Range(MinChangeTime, MaxChangeTime);
                NowTime = 0;
            }
            else
                NowTime += Time.deltaTime;

            if (Player.Horizon_move == "leftmove")
            {

                this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Quaternion.Euler(0, -25, 0), BendSpeed * Time.deltaTime * RandSpeed);
                if (direction != Direction.left)
                {
                    direction = Direction.left;
                    RandSpeed = Random.Range(MinRandSpeed, MaxRandSpeed);
                }
            }



            else if (Player.Horizon_move == "rightmove")
            {
                this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Quaternion.Euler(0, 25, 0), BendSpeed * Time.deltaTime * RandSpeed);
                if (direction != Direction.right)
                {
                    direction = Direction.right;
                    RandSpeed = Random.Range(MinRandSpeed, MaxRandSpeed);
                }
            }

            else
            {
                this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Quaternion.Euler(0, 0, 0), ReturnSpeed * Time.deltaTime * RandSpeed);
                if (direction != Direction.front)
                {
                    direction = Direction.front;
                    RandSpeed = Random.Range(MinRandSpeed, MaxRandSpeed);
                }
            }
        }
     
           


    }
    public void Jump()
    {
        animator.SetBool("Jump", true);
        Invoke("FinishJump",2.0f);
    }
    private void FinishJump()
    {
        animator.SetBool("Jump", false);
    }
}
