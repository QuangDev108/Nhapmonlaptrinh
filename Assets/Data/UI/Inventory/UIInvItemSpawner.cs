using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIInvItemSpawner : Spawner
{
    [SerializeField] protected static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;

    public static string normalItem = "UIInvItems";

    [Header("UI Inventory Spawner")]
    [SerializeField] protected UIInventoryCtril inventoryCtril;
    public UIInventoryCtril InventoryCtril => inventoryCtril;


    protected virtual void LoadUIInventoryCtril()
    {
        if (this.inventoryCtril != null) return;
        this.inventoryCtril = transform.parent.GetComponent<UIInventoryCtril>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryCtril", gameObject);
    }    
    protected override void Awake()
    {
        base.Awake();
        if (UIInvItemSpawner.instance != null) Debug.LogError("Only 1 InvItemSpawner allow to exist");
        UIInvItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtril();

        if (this.holder != null) return;
        this.holder = this.inventoryCtril.Content;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawn(item);
        }    
    }    

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.inventoryCtril.InvItemSpawner.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }    
}
