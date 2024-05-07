using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtril.ItemInventory;
        if(this.playerCtril.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }    
    }    
}
