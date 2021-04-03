using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Make sure this script is attached on one of the UI object
/// </summary>
public class InputManager : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        //if (eventData.pointerCurrentRaycast.gameObject != null)
        //{
        //    Debug.Log("OnDrag " + eventData.pointerCurrentRaycast.gameObject.name);
        //}

        if (CardManagerTutor.instance.SelectedCard != null)
        {
            CardManagerTutor.instance.MoveSelectedCard(eventData.position);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //Debug.Log("OnPointerDown " + eventData.pointerCurrentRaycast.gameObject.name);
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
            {
                CardManagerTutor.instance.SelectCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //Debug.Log("OnPointerUp " + eventData.pointerCurrentRaycast.gameObject.name);
        }

        CardManagerTutor.instance.OnCardRelease();
    }
}
