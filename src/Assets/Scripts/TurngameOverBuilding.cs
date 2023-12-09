using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurngameOverBuilding : MonoBehaviour
{
    private GameObject Player;
    private GameoverController gameoverController;

    private void Start()
    {
        Player = GameObject.Find("Player");
        gameoverController = Player.GetComponent<GameoverController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("atari");
        if(collision.gameObject == Player) 
        {
            if(gameoverController.FailureTurnCheck)
            {
                gameoverController.TurnGameover();
            }
        }
    }
}
