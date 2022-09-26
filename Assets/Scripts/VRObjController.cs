using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRObjController : MonoBehaviour
{
    public void OnPointerEnter()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnPointerExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void OnPointerClick()
    {
        gameObject.SetActive(false);
    }
}
