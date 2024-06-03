using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("Item Upgrade")]
    [SerializeField] protected int maxLevel = 9;

    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }    

    public virtual bool UpgradeItem(int itemIndex)
    {
        if (itemIndex >= this.inventory.Items.Count) return false; // dem item

        ItemInventory iteminventory = this.inventory.Items[itemIndex]; //ktra item
        if (iteminventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = iteminventory.itemProfile.upgradeLevels;
        if(!this.ItemUpgradeable(upgradeLevels)) return false;
        if(!this.HaveEnoughIngredients(upgradeLevels, iteminventory.upgradeLevel)) return false;

        this.DeductIngredients(upgradeLevels, iteminventory.upgradeLevel);
        iteminventory.upgradeLevel++;

        return true;
    }    
    
    protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevels)
    {
        if(upgradeLevels.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevels)
    {
        ItemCode itemCode;
        int itemCount;

        if(currentLevels > upgradeLevels.Count)
        {
            Debug.LogError("Item cant upgrade anymore, current: " + currentLevels);
            return false;
        }

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevels];
        foreach(ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            if(!this.inventory.ItemCheck(itemCode, itemCount)) return false;
        }    
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach(ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            this.inventory.DeductItem(itemCode, itemCount);
        }    
    }    
}
