using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class onClickScript : MonoBehaviour
     , IPointerClickHandler
     , IDragHandler

{
    // Star

    public GraphicRaycaster canvasRaycaster;
    public List<RaycastResult> list;
    public Vector2 screenPoint;

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            print("Clicked " + gameObject.transform.Find("ItemSprite").GetComponent<Image>().sprite.name + " With Right Click");
        else if (eventData.button == PointerEventData.InputButton.Left)
            print("Clicked " + gameObject.transform.Find("ItemSprite").GetComponent<Image>().sprite.name + " With Left Click");
    }
   



}
