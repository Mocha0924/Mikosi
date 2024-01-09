using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksEffectControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Camera;
    [SerializeField] private MikoshiCollisionDetection Player;
    [SerializeField] private ParticleSystem[] Fireworks;
    [SerializeField] private float MaxFireWorksTime;
    private float FireWorksTime = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
            return;
        else if(Player.playerMode == MikoshiCollisionDetection.PlayerMode.Clear)
        {
           
            if (FireWorksTime >= MaxFireWorksTime)
            {
                ParticleSystem newFirework = Instantiate(Fireworks[Random.Range(0, Fireworks.Length)]);
                newFirework.transform.position = Camera.transform.position + (Camera.transform.forward * 500) +(Camera.transform.right*Random.Range(-800f,800f));
                newFirework.transform.position += new Vector3(0, Random.Range(-200, -45), 0);
                newFirework.Play();
                FireWorksTime = 0;
            }
            else
                FireWorksTime += Time.deltaTime;
        }
    }
}
