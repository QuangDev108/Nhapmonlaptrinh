using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : QuangMonoBehaviour
{
    [SerializeField] protected JunkCtril junkCtril;
    public JunkCtril JunkCtril { get => junkCtril; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtril();
    }

    protected virtual void LoadJunkCtril()
    {
        if (this.junkCtril != null) return;
        this.junkCtril = transform.parent.GetComponent<JunkCtril>();
        Debug.Log(transform.name + ": LoadJunkCtril", gameObject);
    }
}
