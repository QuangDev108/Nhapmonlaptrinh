using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;
    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;


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
        InvokeRepeating(nameof(ShowItems), 1, 1);
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

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemInventory> items = PlayerCtril.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.inventoryCtril.InvItemSpawner;

        foreach ( ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
        this.SortItems();
    }

    protected virtual void ClearItems()
    {
        this.inventoryCtril.InvItemSpawner.ClearItems();
    }

    protected virtual void SortItems()
    {
        if(this.inventorySort == InventorySort.NoSort) return;

        //Debug.Log("== InventorySort.ByName  ==");
        int itemCount = this.inventoryCtril.Content.childCount;
        Transform currenItem, nextItem;
        UIItemInventory curentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;
        int currentCount, nextCount;

        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            currenItem = this.inventoryCtril.Content.GetChild(i);
            nextItem = this.inventoryCtril.Content.GetChild(i + 1);

            curentUIItem = currenItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = curentUIItem.ItemInventory.itemProfile;
            nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;
            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    currentName = currentProfile.itemName;
                    nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == 1;
                    //Debug.Log(i + ": " + currentName + " | " + nextName + " = " + isSwap);
                    break;
                case InventorySort.ByCount:
                    currentCount = curentUIItem.ItemInventory.itemCount;
                    nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount > nextCount;
                    break;
            }
            
           
            if (isSwap)
            {
                this.SwapItems(currenItem, nextItem);
                isSorting = true;
            }

        }

        if (isSorting) this.SortItems();//Đệ quy
      
    }    
    
    protected virtual void SwapItems(Transform currenItem, Transform nextItem)
    {
        int currentIndex = currenItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currenItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }    
}
