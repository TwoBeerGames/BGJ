using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Monitor : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float slow = 0f;
    public float timestampSlow = 0.135f;
    public string text;
    public float timeBeforeClose;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void typeText() {
        textComponent.text = string.Empty;
        gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator Type() {
        int index = 0;
        float localSlow = slow;
        foreach (char c in text.ToCharArray())
        {
            index++;
            textComponent.text += c;
            if (index <= 26) {
                localSlow = timestampSlow;
            } else {
                localSlow = slow;
            }
            yield return new WaitForSeconds(localSlow);
        }
        yield return new WaitForSeconds(timeBeforeClose);
        gameObject.SetActive(false);
    }
}
