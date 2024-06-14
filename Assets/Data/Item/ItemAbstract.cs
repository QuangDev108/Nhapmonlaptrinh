using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbstract : QuangMonoBehaviour
{
    [Header("Item Abstract")]
    [SerializeField] protected ItemCtril itemCtril;
    public ItemCtril ItemCtril => itemCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCtril();
    }

    protected virtual void LoadItemCtril()
    {
        if (this.itemCtril != null) return;
        this.itemCtril = transform.parent.GetComponent<ItemCtril>();
        Debug.Log(transform.name + ": LoadItemCtril", gameObject);
    }
}
