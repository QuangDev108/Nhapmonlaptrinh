using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIInventoryAbstract : QuangMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected UIInventoryCtril inventoryCtril;
    public UIInventoryCtril InventoryCtril => inventoryCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtril();
    }
    protected virtual void LoadUIInventoryCtril()
    {
        if (this.inventoryCtril != null) return;
        this.inventoryCtril = transform.parent.GetComponent<UIInventoryCtril>();
        Debug.Log(transform.name + ": LoadUIInventoryCtril", gameObject);
    }
}
