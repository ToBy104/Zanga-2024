﻿using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private int goodLetters_Num;
    [SerializeField]
    private int badLetters_Num;

    [HideInInspector]
    public bool isLettersGood;
    [HideInInspector]
    public bool isLettersBad;

    public GameObject drop;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            //if(correctLetters_Num.Contains(eventData.pointerDrag.GetComponent<DragDrop>().index))

            int letterIndex = eventData.pointerDrag.GetComponent<DragDrop>().index;
            if(letterIndex == badLetters_Num && letterIndex == goodLetters_Num)
            {
                isLettersGood = true;
                isLettersBad  = true;

                drop = eventData.pointerDrag;
            }
            else if (letterIndex == goodLetters_Num)
            {
                isLettersGood = true;
                isLettersBad  = false;

                drop = eventData.pointerDrag;
            }
            else if (letterIndex == badLetters_Num)
            {
                isLettersBad  = true;
                isLettersGood = false;

                drop = eventData.pointerDrag;
            }
            else
            {
                isLettersGood = false;
                isLettersBad  = false;
            }
        }
    }
}
