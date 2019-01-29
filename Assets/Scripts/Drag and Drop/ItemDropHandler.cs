using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropHandler : MonoBehaviour, IDropHandler {

    
    // Use this for initialization
    void Start() {
     
    }

    public void OnDrop(PointerEventData eventData) {
        RectTransform sentenceLine = transform as RectTransform;
        
        if(!RectTransformUtility.RectangleContainsScreenPoint(sentenceLine, Input.mousePosition)) {
            
        }

        
    }
}
