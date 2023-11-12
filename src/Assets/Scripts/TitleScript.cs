using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    bool toStage = false;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float displayImageDuration = 1f;
    [SerializeField] CanvasGroup canvasGroup;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip ClickSound;
    float m_timer;

    // Update is called once per frame
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (toStage)
        {
            FadeOut();
        }
    }

    public void ClickStartButton()
    {
        _audioSource.PlayOneShot(ClickSound);
        toStage = true;
    }

    void FadeOut()
    {
        m_timer += Time.deltaTime;

        canvasGroup.alpha = m_timer / fadeDuration;

        if (m_timer > fadeDuration + displayImageDuration)
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
