using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : QuangMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.IronOre, 21);
        this.AddItem(ItemCode.CopperSword, 3);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExits;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExits = this.GetItemNotFullStack(itemCode);
            if (itemExits == null)
            {
                if(this.IsInventoryFull()) return false;

                itemExits = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExits);
            }

            newCount = itemExits.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExits);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExits.itemCount;
                newCount = itemExits.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExits.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }

    protected virtual bool IsInventoryFull()
    {
        if(this.items.Count >= this.maxSlot) return true;
        return false;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if(itemInventory == null) return 0;
        return itemInventory.maxStack;
    }
    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if(itemCode != itemInventory.itemProfile.itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }
        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory != null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }
    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };
        return itemInventory;
    }
}
