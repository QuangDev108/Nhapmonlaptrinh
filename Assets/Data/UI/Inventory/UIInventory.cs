using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;


    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exits");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        //this.Close();
        InvokeRepeating(nameof(ShowItem), 1, 1);
    }

    protected virtual void FixedUpdate()
    {
       // this.ShowItem();
    }    
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen ) this.Open();
        else this.Close();
    }    
    public virtual void Open()
    {
        this.inventoryCtril.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close ()
    {
        this.inventoryCtril.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemInventory> items = PlayerCtril.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.inventoryCtril.InvItemSpawner;

        foreach ( ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
    }    

    protected virtual void ClearItems()
    {
        this.inventoryCtril.InvItemSpawner.ClearItems();
    }    
}
