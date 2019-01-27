using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler  {

    private AudioSource[] audio;
    private Canvas canvas;
    private Text text;

    void Start() {
        text = GetComponent <Text> ();
        audio = GetComponents<AudioSource>();
        canvas = GameObject.FindObjectOfType<Canvas>();
    }

    public void OnDrag(PointerEventData eventData) {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData) {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f;

        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        transform.parent = canvas.transform;

        ItemDropHandler[] dropHandlers = GameObject.FindObjectsOfType<ItemDropHandler>();
        foreach(ItemDropHandler dropHandler in dropHandlers) {
            RectTransform rectTransform = dropHandler.transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Camera.main.ScreenToWorldPoint(screenPoint))) {
                transform.position = dropHandler.transform.position;
                transform.parent = dropHandler.transform;
                audio[1].pitch = Random.Range(0.95f, 1.1f);
                audio[1].Play();

                FloatingText floatingTextObject = GetComponent<FloatingText>();
                Storyboard storyboard = GameObject.FindObjectOfType<Storyboard>();

                if(floatingTextObject != null) {
                    if(storyboard != null) {
                        floatingTextObject.set = true;
                        storyboard.StartScene(floatingTextObject.GetPath());
                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
