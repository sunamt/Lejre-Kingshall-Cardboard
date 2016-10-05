using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    [SerializeField] private Renderer sphere;
    [SerializeField] private Color fadeIn;  // fad1e in, lowering alpha
    [SerializeField] private Color fadeOut;        // fade out, increasing alpha
    [SerializeField] private float fadeDuration = 2.0f;
    [SerializeField] private bool isFading { get; set; }
    
    void Start()
    {
        //FadeIn(); Here? some on load? scenemanager.onload
        fadeIn = new Color(1, 1, 1, 0);
        fadeOut = Color.white;
        FadeIn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FadeIn(fadeDuration);
            return;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            FadeOut(fadeDuration);
            return;
        }
    }

    void FadeOut()
    {
        FadeOut(fadeDuration);
    }

    void FadeIn()
    {
        FadeIn(fadeDuration);
    }

    void FadeOut(float duration)
    {
        if (isFading)
            return;
        StartCoroutine(BeginFade(fadeIn, fadeOut, duration));
    }

    void FadeIn(float duration)
    {
        if (isFading)
            return;
        StartCoroutine(BeginFade(fadeOut, fadeIn, duration));
    }

    private IEnumerator BeginFade(Color start, Color end, float duration)
    {
        isFading = true;
        float timer = 0f;
            
        while (timer <= duration)
        {
            sphere.material.color = Color.Lerp(start, end, timer / duration);
            //sphere.material.SetFloat("_Alpha", 1-timer); if using unlit/transparentparam, need to change input to change between 1- and 0+
            timer += Time.deltaTime;
            yield return null;
        }

        isFading = false;
    }
}