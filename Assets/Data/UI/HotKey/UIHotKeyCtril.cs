using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtril : QuangMonoBehaviour
{
    private static UIHotKeyCtril instance;
    public static UIHotKeyCtril Instance => instance;

    public List<ItemSlot> itemSlots;

    protected override void Awake()
    {
        if (UIHotKeyCtril.instance != null) Debug.LogError("Only 1 UIHotKeyCtril allow to exits");
        UIHotKeyCtril.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;
        ItemSlot[] arraySlots = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arraySlots);
        Debug.Log(transform.name + ": LoadItemSlots", gameObject);
    }
}
