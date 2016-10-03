using UnityEngine;
using System.Collections;

/// <summary>
/// This script fades between two renderers/game objects and change their material.
/// This is to be used on planes placed over the the fireplace.
/// </summary>
public class PlaneFader : MonoBehaviour {

    [SerializeField] private Renderer plane1;   // Set in inspector
    [SerializeField] private Renderer plane2;   // Set in inspector
    [SerializeField] private Material[] mats;   // Set in inspector
    System.Random rnd = new System.Random();

    public FadeAction action;
    private FadeAction oldAction;

    float fadeDuration = 2f;
    public float waitDuration = 3f;

    void Start ()
    {
        plane1.material = mats[0];
        plane2.material = mats[0];

        action = FadeAction.ShowOne;
        oldAction = FadeAction.ShowTwo;  
    }

    void Update()
    {
        if (!action.Equals(oldAction))
        {
            if (action.Equals(FadeAction.ShowOne))
            {
                oldAction = action;
                Fade(plane2, fadeDuration, false);
                Fade(plane1, fadeDuration, true);
                ChangeMaterial(plane2, waitDuration, FadeAction.ShowTwo);
            }
            if (action.Equals(FadeAction.ShowTwo))
            {
                oldAction = action;
                Fade(plane1, fadeDuration, false);
                Fade(plane2, fadeDuration, true);
                ChangeMaterial(plane1, waitDuration, FadeAction.ShowOne);
            }
        }
    }

    void Fade(Renderer plane, float duration, bool fadein)
    {
        StartCoroutine(BeginFade(plane, duration, fadein));
    }

    void ChangeMaterial(Renderer plane, float seconds, FadeAction newAction)
    {
        StartCoroutine(ChangeMat(plane, seconds, newAction));
    }

    private IEnumerator ChangeMat(Renderer plane, float seconds, FadeAction newAction)
    {
        Material mat = mats[rnd.Next(mats.Length - 1)];
        plane.material = mat;

        yield return new WaitForSeconds(seconds);

        waitDuration = Random.Range(2f, 3f);
        action = newAction;
        

    }

    private IEnumerator BeginFade(Renderer plane, float duration, bool fadein)
    {
        float timer = 0f;
        while (timer <= duration)
        {
            if (fadein)
                plane.material.SetFloat("_Alpha", 1 - timer);
            else
                plane.material.SetFloat("_Alpha", 0 + timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public enum FadeAction { ShowOne, ShowTwo }
}
