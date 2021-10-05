using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject firstKey;

    public void Type(VirtualKey key)
    {
        key.Modify(inputField);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Invoke("Select", 0.0f);
    }

    public void Select()
    {
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(firstKey);
        }
    }
}
