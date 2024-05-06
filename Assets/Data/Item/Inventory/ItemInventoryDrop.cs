using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5);
    }

    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }    

    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Debug.Log(itemInventory.itemProfile.itemCode);
        Debug.Log(itemInventory.upgradeLevel);

        Vector3 droPos = transform.position;
        droPos.x += 1;
        ItemDropSpawner.Instance.Drop(itemInventory,droPos,transform.rotation);
    }    
}
