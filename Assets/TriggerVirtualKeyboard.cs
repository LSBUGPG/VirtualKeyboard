using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVirtualKeyboard : MonoBehaviour
{
    public VirtualKeyboard keyboard;

    public void PopUp()
    {
        keyboard.Open();
    }
}
