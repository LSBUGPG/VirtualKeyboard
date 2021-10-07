using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class Key
{
    public KeyCode code;
    public string unshifted;
    public string shifted;
}

[System.Serializable]
public class Row
{
    public Key[] keys;
}


public class VirtualKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public VirtualKey keyPrefab;
    public HorizontalLayoutGroup rowPrefab;
    public Row[] rows;

    GameObject firstKey;
    bool capsLock = false;
    bool shift = false;
    BaseEventData dummy;

    void Start()
    {
        foreach (Row row in rows)
        {
            HorizontalLayoutGroup keyRow = Instantiate<HorizontalLayoutGroup>(rowPrefab, transform);
            foreach (Key key in row.keys)
            {
                VirtualKey virtualKey = Instantiate<VirtualKey>(keyPrefab, keyRow.transform);
                virtualKey.code = key.code;
                virtualKey.shifted = key.shifted;
                virtualKey.unshifted = key.unshifted;

                if (firstKey == null)
                {
                    firstKey = virtualKey.gameObject;
                }
            }
        }
    }

    public void Return()
    {
        gameObject.SetActive(false);
    }

    void UpdateShift()
    {
        BroadcastMessage("Shift", shift);
    }

    public void ToggleShift()
    {
        if (capsLock)
        {
            capsLock = false;
        }
        shift = !shift;
        UpdateShift();
    }

    public void ToggleCapsLock()
    {
        capsLock = !capsLock;
        shift = capsLock;
        UpdateShift();
    }

    public void Type(VirtualKey key)
    {
        key.Modify(inputField);
        if (!capsLock && shift)
        {
            shift = false;
            UpdateShift();
        }
    }


    public void Open()
    {
        gameObject.SetActive(true);
        CanvasUpdateRegistry.RegisterCanvasElementForGraphicRebuild(inputField);
    }

    public void Select()
    {
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(firstKey);
        }
    }
}
