using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverController : MonoBehaviour
{
    [SerializeField] private GameObject Whole;
    private MikoshiCollisionDetection mikosiCollision;
    public bool FailureTurnCheck = false;
    [SerializeField] private RigdollController[] ragdoll;
    [SerializeField] private MikosiRagdollController mikosiRagdoll;
    [SerializeField] private AudioSource mikosiAudioSource;
    [SerializeField] private AudioClip FailureTurnSound;
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
        mikosiRagdoll.SetPhysics();
        Invoke(nameof(Gameover), 3.5f);
    }
    public void TurnGameover()
    {
        mikosiCollision.GameOverDirection();
        mikosiRagdoll.SetRagDoll();
        mikosiAudioSource.PlayOneShot(FailureTurnSound);
        Invoke(nameof(Gameover), 3.5f);
    }
    public void CarHit()
    {
        mikosiRagdoll.SetRagDoll();
        Invoke(nameof(Gameover), 3.5f);
    }
    private void Gameover()
    {
        mikosiCollision.Gameover();
    }
}
