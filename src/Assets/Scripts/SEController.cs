using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip CaveatSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Caveat()
    {
        audioSource.PlayOneShot(CaveatSound);
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
}
