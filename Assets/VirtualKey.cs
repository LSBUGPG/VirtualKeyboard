using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VirtualKey : MonoBehaviour
{
    public KeyCode code;
    public string unshifted;
    public string shifted;
    public TextMeshProUGUI keyCap;

    VirtualKeyboard keyboard;

    void Start()
    {
        keyboard = GetComponentInParent<VirtualKeyboard>();
        keyCap.text = unshifted;
    }

    public void OnClick()
    {
        keyboard.Type(this);
    }

    public void Modify(TMP_InputField field)
    {
        field.SetTextWithoutNotify(field.text + unshifted);
        field.ForceLabelUpdate();
    }
}
