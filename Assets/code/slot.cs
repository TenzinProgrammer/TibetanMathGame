using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour, IDropHandler
{
    Text text;
    public Text display;
    public static bool PointerIsOnSlot = false;
    manager canvas;
    private bool rightAns = true;
    public int score;
    public ParticleSystem particle;

    //startPosition = transform.position;
    // Start is called before the first frame update
    void Start() {
        score = 0;
        text = GameObject.Find("drop").GetComponent<Text>();
    }
    public void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            score =+ 1;
            particle.Play();
            print("score is" + scoreManager.score);
            display.text = score.ToString("Score : " + scoreManager.score);
            print("dropped");
            text.text = "";
            if(eventData.pointerDrag == rightAns && gameObject.tag == "right") {
              print("right ans");
            } else if(eventData.pointerDrag == rightAns && gameObject.tag == "wrong") {
              print("wrong asn");
            }
        } 
    }

    public void PointerOnSlot() {
        PointerIsOnSlot = true;
    }
    public void PointerOutSlot() {
        PointerIsOnSlot = false;
    }
}
