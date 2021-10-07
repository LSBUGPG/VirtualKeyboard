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
    bool shift = false;

    void Start()
    {
        keyboard = GetComponentInParent<VirtualKeyboard>();
        keyCap.text = unshifted;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta += Vector2.right * keyCap.preferredWidth;
    }

    public void OnClick()
    {
        switch (code)
        {
            case KeyCode.CapsLock:
                keyboard.ToggleCapsLock();
                break;

            case KeyCode.Return:
                keyboard.Return();
                break;

            case KeyCode.LeftShift:
            case KeyCode.RightShift:
                keyboard.ToggleShift();
                break;

            default:
                keyboard.Type(this);
                break;
        }
    }

    public void Modify(TMP_InputField field)
    {
        field.ProcessEvent(GetKeyboardEvent());
        field.ForceLabelUpdate();
    }

    Event GetKeyboardEvent()
    {
        Event keyboardEvent = Event.KeyboardEvent(shift ? ("#" + shifted) : shifted);
        keyboardEvent.character = (char)(shift? shifted : unshifted)[0];
        Debug.Log(keyboardEvent);
        return keyboardEvent;
    }

    string GetKeyString()
    {
        return shift ? shifted : unshifted;
    }

    public void Shift(bool shift)
    {
        this.shift = shift;
        keyCap.text = GetKeyString();
    }
}
