using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VirtualKey : MonoBehaviour
{
    RectTransform rectTransform;
    public KeyCode code;
    public string unshifted;
    public string shifted;
    public TextMeshProUGUI keyCap;

    VirtualKeyboard keyboard;

    void Start()
    {
        keyboard = GetComponentInParent<VirtualKeyboard>();
        keyCap.text = unshifted;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta += Vector2.right * keyCap.preferredWidth;
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
