using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class onClickNode : MonoBehaviour
     , IPointerClickHandler
     , IDragHandler

{
    // Star
    public bool active = false;

    void Awake() 
    {
        if (!active) {
            var tempColor = UnityEngine.Color.grey;
            tempColor.a = 0.2f;
            gameObject.transform.Find("Background").GetComponent<Image>().color =tempColor;
        }

    }

    public void setActive(bool act) { 
        if (act)
            gameObject.transform.Find("Background").GetComponent<Image>().color = UnityEngine.Color.white;
        active = act; 
    }
    public bool getActive() { return active; }
    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && active)
            print("Clicked " + gameObject.transform.Find("ItemText").GetComponent<Text>().text + " With Right Click and Active");
        else if(eventData.button == PointerEventData.InputButton.Right && !active)
            print("Clicked " + gameObject.transform.Find("ItemText").GetComponent<Text>().text + " With Right Click and Not Active");

        else if (eventData.button == PointerEventData.InputButton.Left && active)
            print("Clicked " + gameObject.transform.Find("ItemText").GetComponent<Text>().text + " With Left Click and Active");

        else if (eventData.button == PointerEventData.InputButton.Left && !active)
            print("Clicked " + gameObject.transform.Find("ItemText").GetComponent<Text>().text + " With Left Click and Not Active");
    }
   



}
