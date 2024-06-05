using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtril : QuangMonoBehaviour
{
    private static UIHotKeyCtril instance;
    public static UIHotKeyCtril Instance => instance;

    protected override void Awake()
    {
        if (UIHotKeyCtril.instance != null) Debug.LogError("Only 1 UIHotKeyCtril allow to exits");
        UIHotKeyCtril.instance = this;
    }
}
