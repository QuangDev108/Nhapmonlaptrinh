using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("itemPickup");

        ItemCode itemCode = itemPickupable.GetItemCode();
        if(this.playerCtril.CurrentShip.Inventory.AddItem(itemCode,1))
        {
            itemPickupable.Picked();
        }    
    }    
}
