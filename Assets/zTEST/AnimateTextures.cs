using UnityEngine;
using System.Collections;

public class AnimateTextures : MonoBehaviour
{
    [SerializeField] private Material[] mats;   // set in hierarchy
    [SerializeField] private Renderer plane1;   // set in hierarchy
    [SerializeField] private Renderer plane2;   // set in hierarchy

    System.Random rnd;
    bool isFadingOne;
    bool isFadingTwo;
    float fadeDuration = 2f;
    Color noAlpha;
    Color alpha;

    void Start()
    {
        rnd = new System.Random();
        isFadingOne = false;
        isFadingTwo = false;

        plane1.material = mats[0];
        plane2.material = mats[0];

        Fade(plane2.material.color, 
            new Color(plane2.material.color.r, plane2.material.color.g, plane2.material.color.b, 0),
            fadeDuration, false);

    }

    void Fade(Color start, Color end, float duration, bool planeOne)
    {
        if (planeOne)
            StartCoroutine(FadePlaneOne(start, end, duration));
        else
            StartCoroutine(FadePlaneTwo(start, end, duration));
    }

    private IEnumerator FadePlaneOne(Color start, Color end, float duration)
    {
        isFadingOne = true;
        float timer = 0f;

        while (timer <= duration)
        {
            plane1.material.color = Color.Lerp(start, end, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        isFadingOne = false;
    }

    private IEnumerator FadePlaneTwo(Color start, Color end, float duration)
    {
        isFadingTwo = true;
        float timer = 0f;

        while (timer <= duration)
        {
            plane2.material.color = Color.Lerp(start, end, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        isFadingTwo = false;
    }


    /*
     * float time;

    void Start()
    {
        rnd = new System.Random();
        time = Time.fixedTime + 2f;
    }

    void FixedUpdate()
    {
        if (Time.fixedTime >= time)
        {
            Lerp(mats[rnd.Next(rnd.Next(mats.Length - 1))]);
            time = Time.fixedTime + 2f;
        }
    }

    void Lerp(Material mat)
    {
        float lerp = Mathf.PingPong(Time.time, 2) / 2;
        Material m = gameObject.GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().material.Lerp(m, mat, lerp);
    }

    */

    /*
    string path;
    public Material[] materials;
    bool looping;
    System.Random rnd;
    int max;

    void Start()
    {
        rnd = new System.Random();
        max = materials.Length - 1;

        LoopingMats();      
    }

    void ChangeMaterial(Material mat)
    {
        float lerp = Mathf.PingPong(Time.time, 10) / 10;
        gameObject.GetComponent<Renderer>().material.Lerp(gameObject.GetComponent<Renderer>().material, mat, lerp);
    }

    void LoopingMats()
    {
        StartCoroutine(Wait());
        int n = rnd.Next(max);
        ChangeMaterial(materials[n]);
    }

    void StartLooping()
    {
        looping = true;
    }

    void StopLooping()
    {
        looping = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
    */

    /*
    public string path;
    Texture[] framesTex;
    Material[] framesMat;
    float framesPerSecond = 10f;

    void Start()
    {     
        framesTex = Resources.LoadAll<Texture>(path);
        framesMat = Resources.LoadAll<Material>(path);
    }

    void Update()
    {
        AnimateMaterial();
    }

    void AnimateTexture()
    {
        int index = (int)(Time.time * framesPerSecond) % framesTex.Length;
        gameObject.GetComponent<Renderer>().material.mainTexture = framesTex[index];
    }

    void AnimateMaterial()
    {
        int index = (int)(Time.time * framesPerSecond) % framesMat.Length;
        gameObject.GetComponent<Renderer>().material = framesMat[index];
    }
    */

}