using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverController : MonoBehaviour
{
    [SerializeField] private GameObject Whole;
    private MikoshiCollisionDetection mikosiCollision;
    public bool FailureTurnCheck = false;
    [SerializeField] private RigdollController[] ragdoll; 
    private void Start()
    {
        mikosiCollision = GetComponent<MikoshiCollisionDetection>();
    }
    public void FailureTurn()
    {
        FailureTurnCheck = true;

    }
    public void Disapper()
    {
        foreach(RigdollController r in ragdoll) 
        {
            r.SetRagDoll();
        }
        Invoke(nameof(Gameover), 3.5f);
    }
    public void TurnGameover()
    {
        mikosiCollision.GameOverDirection();
        foreach (RigdollController r in ragdoll)
        {
            r.SetRagDoll();
        }
        Invoke(nameof(Gameover), 3.5f);
    }
   private void Gameover()
    {
        mikosiCollision.Gameover();
    }
}
