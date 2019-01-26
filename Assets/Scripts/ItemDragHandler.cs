using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler  {

    public Canvas canvas;

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
        transform.parent = canvas.transform;

        ItemDropHandler[] dropHandlers = GameObject.FindObjectsOfType<ItemDropHandler>();
        foreach(ItemDropHandler dropHandler in dropHandlers) {
            RectTransform rectTransform = dropHandler.transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition)) {
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
