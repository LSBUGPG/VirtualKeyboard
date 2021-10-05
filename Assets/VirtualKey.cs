using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VirtualKey : MonoBehaviour
{
    public KeyCode code;

    VirtualKeyboard keyboard;

    void Start()
    {
        keyboard = GetComponentInParent<VirtualKeyboard>();
    }

    public void OnClick()
    {
        keyboard.Type(this);
    }

    public void Modify(TMP_InputField field)
    {
        field.SetTextWithoutNotify(field.text + code.ToString());
        field.ForceLabelUpdate();
    }
}
