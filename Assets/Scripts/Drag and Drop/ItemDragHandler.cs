using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    [SerializeField] AudioClip[] choiceAudio;
    AudioSource myAudioSource;
    private Canvas canvas;
    private Text text;
    [SerializeField] Text answerText;
    Text narratorText;
    AudioSource audioSourceActivate;
    [SerializeField] int narratorCount = 0;
    [SerializeField] float musicFadeOutTime = 2f;

    public bool grabable = true;

    void Start() {
        text = GetComponent<Text>();
        myAudioSource = GetComponent<AudioSource>();
        canvas = GameObject.FindObjectOfType<Canvas>();
        narratorText = GameObject.Find("NarratorText").GetComponent<Text>();
    }

    public void OnDrag(PointerEventData eventData) {
        if (!grabable) {
            return;
        }

        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData) {
        if(!grabable) {
            return;
        }

        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f;

        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        transform.parent = canvas.transform;

        ItemDropHandler[] dropHandlers = GameObject.FindObjectsOfType<ItemDropHandler>();
        foreach (ItemDropHandler dropHandler in dropHandlers) {
            RectTransform rectTransform = dropHandler.transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Camera.main.ScreenToWorldPoint(screenPoint))) {
                transform.position = dropHandler.transform.position;
                transform.parent = dropHandler.transform;
                AudioClip clip = choiceAudio[UnityEngine.Random.Range(0, choiceAudio.Length)];
                myAudioSource.PlayOneShot(clip);
                //choiceAudio[1].pitch = Random.Range(0.95f, 1.1f);
                //choiceAudio[1].Play();

                FloatingText floatingTextObject = GetComponent<FloatingText>();
                Storyboard storyboard = GameObject.FindObjectOfType<Storyboard>();

                if (floatingTextObject != null) {
                    if (storyboard != null) {
                        floatingTextObject.set = true;
                        storyboard.StartScene(floatingTextObject.GetPath());
                    }
                }

                switch (answerText.text)
                {
                    case "Big":
                        audioSourceActivate = GameObject.Find("BigHouseMusic").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("Big HouseBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Small":
                        audioSourceActivate = GameObject.Find("SmallHouseMusic").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("Small HouseBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Birds":
                        audioSourceActivate = GameObject.Find("BirdsMusic").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("BirdsBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Traffic":
                        audioSourceActivate = GameObject.Find("TrafficMusic").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("TrafficBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Neighbors":
                        audioSourceActivate = GameObject.Find("NeighborsMusic").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("NeighborsBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Swingset":
                        audioSourceActivate = GameObject.Find("SwingsetMusic").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("SwingsetBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Firepit":
                        audioSourceActivate = GameObject.Find("Firepit").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("FirepitBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Garden":
                        audioSourceActivate = GameObject.Find("Garden").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("GardenBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Oak Tree":
                        audioSourceActivate = GameObject.Find("Oak Tree").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("Oak TreeBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Pine Tree":
                        audioSourceActivate = GameObject.Find("Pine Tree").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("Pine TreeBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "Picnic Table":
                        audioSourceActivate = GameObject.Find("Picnic Table").GetComponent<AudioSource>();
                        audioSourceActivate.enabled = !audioSourceActivate.enabled;
                        GameObject.Find("Picnic TableBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;

                    case "You are?":
                        StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Who Would").GetComponent<AudioSource>(), musicFadeOutTime));
                        GameObject.Find("HospitalBG").GetComponent<BackgroundFadeIn>().StartFadeIn();
                        break;
                }
                CheckNarrator();
            }
        }
    }

    // Update is called once per frame
    void Update() {
       
    }

    public void CheckNarrator()
    {
        
        if (narratorText.text == "What else was in the front yard?" && FindObjectOfType<LineManager>().narratorCount == 0)
        {
            audioSourceActivate = GameObject.Find("Else In Front").GetComponent<AudioSource>();
            audioSourceActivate.enabled = !audioSourceActivate.enabled;
            FindObjectOfType<LineManager>().AddNarrator();
        }

        if((narratorText.text == "You would eat by yourself?" || narratorText.text == "You would wake up on you own?") && FindObjectOfType<LineManager>().narratorCount == 1)
        {
            audioSourceActivate = GameObject.Find("Who Would").GetComponent<AudioSource>();
            audioSourceActivate.enabled = !audioSourceActivate.enabled;
            FindObjectOfType<LineManager>().AddNarrator();
        }

        if (narratorText.text == "Who do you enjoy life with?" && FindObjectOfType<LineManager>().narratorCount == 2)
        {
            audioSourceActivate = GameObject.Find("Enjoy Life With").GetComponent<AudioSource>();
            audioSourceActivate.enabled = !audioSourceActivate.enabled;
            FindObjectOfType<LineManager>().AddNarrator();

            //Deactivate all other music
            if (GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled == true)
            {
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Main Camera").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("BigHouseMusic").GetComponent<AudioSource>().enabled == true)
            {
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("BigHouseMusic").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("SmallHouseMusic").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("SmallHouseMusic").GetComponent<AudioSource>().enabled = !GameObject.Find("SmallHouseMusic").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("SmallHouseMusic").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("BirdsMusic").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("BirdsMusic").GetComponent<AudioSource>().enabled = !GameObject.Find("BirdsMusic").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("BirdsMusic").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("NeighborsMusic").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("NeighborsMusic").GetComponent<AudioSource>().enabled = !GameObject.Find("NeighborsMusic").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("NeighborsMusic").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("TrafficMusic").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("TrafficMusic").GetComponent<AudioSource>().enabled = !GameObject.Find("TrafficMusic").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("TrafficMusic").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("SwingsetMusic").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("SwingsetMusic").GetComponent<AudioSource>().enabled = !GameObject.Find("SwingsetMusic").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("SwingsetMusic").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("Firepit").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("Firepit").GetComponent<AudioSource>().enabled = !GameObject.Find("Firepit").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Firepit").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("Garden").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("Garden").GetComponent<AudioSource>().enabled = !GameObject.Find("Garden").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Garden").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("Oak Tree").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("Oak Tree").GetComponent<AudioSource>().enabled = !GameObject.Find("Oak Tree").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Oak Tree").GetComponent<AudioSource>(), musicFadeOutTime));

            }

            if (GameObject.Find("Pine Tree").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("Pine Tree").GetComponent<AudioSource>().enabled = !GameObject.Find("Pine Tree").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Pine Tree").GetComponent<AudioSource>(), musicFadeOutTime));
            }

            if (GameObject.Find("Picnic Table").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("Picnic Table").GetComponent<AudioSource>().enabled = !GameObject.Find("Picnic Table").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Picnic Table").GetComponent<AudioSource>(), musicFadeOutTime));
                
            }

            if (GameObject.Find("Else In Front").GetComponent<AudioSource>().enabled == true)
            {
                //GameObject.Find("Else In Front").GetComponent<AudioSource>().enabled = !GameObject.Find("Else In Front").GetComponent<AudioSource>().enabled;
                StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Else In Front").GetComponent<AudioSource>(), musicFadeOutTime));
            }
        }

    }
}
