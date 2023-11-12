using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip ClickSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SceneChange(string SceneName)
    {
        _audioSource.PlayOneShot(ClickSound);
        SceneManager.LoadScene(SceneName);
    }
    public void FinishGame()
    {
        _audioSource.PlayOneShot(ClickSound);
        Application.Quit();
    }
}
