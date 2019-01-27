using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

    private Text text;
    private ItemDragHandler itemDragHandler;
    private ParticleSystem particleSystemRenderer;
    private AudioSource [] audio;
    private SceneObject path;

    public string word;
    public bool set = false;

    public void Init(string text, SceneObject path) {
        if(this.text == null) {
            this.text = GetComponent<Text>();
        }

        this.path = path;

        this.text.text = text;
        word = text;
    }

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        itemDragHandler = GetComponent<ItemDragHandler>();
        particleSystemRenderer = GetComponentInChildren<ParticleSystem>();
        audio = GetComponents<AudioSource>();

        text.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 0f, 0f);
        itemDragHandler.enabled = false;
        audio[0].pitch = Random.Range(0.85f, 1.1f);
        audio[0].Play();

        StartCoroutine("FadeIn");
    }

    public SceneObject GetPath() {
        return path;
    }

    IEnumerator FadeIn() {
        for(int i = 0; i < 10; i++) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0.1f * i);
            yield return new WaitForSeconds(0.1f);
        }

        itemDragHandler.enabled = true;
        StartCoroutine("Fluctuate");
    }

    public void BeginFadeOut() {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut() {
        GetComponentInChildren<ParticleSystem>().Stop();

        for (int i = 10; i >= 0; i--) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0.1f * i);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }

    IEnumerator Fluctuate() {
        while(!set) {
            Color newColor = Random.ColorHSV(0.5f, 1f, 0.5f, 1f, 0.2f, 1f);

            for(float i = 0f; i < 1f && !set; i += 0.01f) {
                text.color = Color.Lerp(text.color, newColor, i);
                //particleSystemRenderer.material.SetColor("Tint Color", text.color);
                particleSystemRenderer.startColor = text.color;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
