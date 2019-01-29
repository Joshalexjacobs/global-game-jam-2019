using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundFadeIn : MonoBehaviour {

    private Image image;

    public bool fadeInOnStart = false;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();

        if (fadeInOnStart) {
            StartCoroutine("FadeIn");
        }
	}

    public void StartFadeIn() {
        StartCoroutine("FadeIn");
    }

    public void StartFadeOut() {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn() {
        for (int i = 0; i <= 10; i++) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.1f * i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut() {
        for (int i = 10; i >= 0; i--) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.1f * i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
