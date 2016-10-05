using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SphereFader : MonoBehaviour {

    [SerializeField]
    private Renderer sphere;
    [SerializeField]
    private float fadeDuration = 2.0f;
    
    void Start()
    {
        sphere = gameObject.GetComponent<Renderer>();
        FadeAlphaDown(fadeDuration);
    }

    public void FadeAlphaUp(string s)
    {
        FadeAlphaUp(s, fadeDuration);
    }

    void FadeAlphaUp(string s, float duration)
    {
        StartCoroutine(FadeAlpha(s, fadeDuration));
    }

    void FadeAlphaDown(float duration)
    {
        StartCoroutine(FadeAlpha(false, fadeDuration));
    }

    IEnumerator FadeAlpha(bool direction, float duration) //direction = true is alpha up
    {
        float timer = 0;
        while (timer <= duration)
        {
            if (direction)
                sphere.material.SetFloat("_Alpha", 0 + timer / duration);
            else
                sphere.material.SetFloat("_Alpha", 1 - timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeAlpha(string s, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {
            sphere.material.SetFloat("_Alpha", 0 + timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(s);
    }
}
