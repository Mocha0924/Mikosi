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

    float m_timer;

    // Update is called once per frame
    void Update()
    {
        if (toStage)
        {
            FadeOut();
        }
    }

    public void ClickStartButton()
    {
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
