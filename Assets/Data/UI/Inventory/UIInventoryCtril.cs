using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtril : QuangMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIInvItemSpawner invItemSpawner;
    public UIInvItemSpawner InvItemSpawner => invItemSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInvItemSpawner();
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }
    protected virtual void LoadUIInvItemSpawner()
    {
        if (this.invItemSpawner != null) return;
        this.invItemSpawner = transform.GetComponentInChildren<UIInvItemSpawner>();
        Debug.Log(transform.name + ": LoadUIInvItemSpawner", gameObject);
    }
}
