using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPulse : MonoBehaviour {

    [SerializeField] private Image button;
    [SerializeField] private bool pulse;
    [SerializeField] private bool wait;

    void Start()
    {
        button = gameObject.GetComponent<Image>();
        pulse = true;
        wait = false;
    }

	void Update()
    {
        if (wait == false)
        {
            wait = true;

            if (pulse == true)
            {
                pulse = false;
                //StartCoroutine(ChangeColor(Color.white, Color.green, 2));
                ChangeColor(Color.white, Color.green, 2);
                Debug.Log("Changed Color, W>G");
            }

            if (pulse == false)
            {
                pulse = true;
                //StartCoroutine(ChangeColor(Color.green, Color.white, 2));
                ChangeColor(Color.green, Color.white, 2);
                Debug.Log("Changed Color, G<W");
            }

            wait = false;
        }
    }

    void ChangeColor(Color start, Color end, float duration)
    {
        float timer = 0f;
        while (timer <= duration)
        {
            button.color = Color.Lerp(start, end, timer / duration);
            timer += Time.deltaTime;
        }
    }

    /*
    IEnumerator ChangeColor(Color start, Color end, float duration)
    {
        float timer = 0f;
        while (timer <= duration)
        {
            button.color = Color.Lerp(start, end, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    */
}
