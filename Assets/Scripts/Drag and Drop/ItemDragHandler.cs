using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler  {

    public Canvas canvas;

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
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
