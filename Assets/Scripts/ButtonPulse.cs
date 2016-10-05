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
                StartCoroutine(Change(button.color, Color.green, 2));
            }

            else if (pulse == false)
            {
                StartCoroutine(Change(button.color, Color.white, 2));
            }

        }
    }

    IEnumerator Change(Color start, Color end, float duration)
    {
        float timer = 0f;
        while (timer <= duration)
        {
            button.color = Color.Lerp(start, end, timer / duration);
            timer = timer + Time.deltaTime;
        }

        yield return new WaitForSeconds(duration);

        pulse = !pulse;
        wait = !wait;
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
