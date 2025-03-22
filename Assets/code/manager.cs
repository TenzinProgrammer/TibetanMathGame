using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class manager : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] public CanvasGroup canvasGroup;
    public Text title;
    Vector2 initialPos; //declare variable of initial position
    
    public void Awake()
    {
        title = GameObject.Find("drop").GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPos = rectTransform.anchoredPosition; //get info of rect tranform of game object
    }
    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;
        title.text = "ལན་འདིར་ཞོག";
    }
    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData) {
     if(!slot.PointerIsOnSlot) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        print("Back to Initial Position");
        rectTransform.anchoredPosition = initialPos;
     }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print("onPointerDown");
    }
}