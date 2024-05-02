using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : QuangMonoBehaviour
{
    [Header("PlayerAbstract")]
    [SerializeField] protected PlayerCtril playerCtril;
    //public PlayerCtril PlayerCtril => playerCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtril();
    }

    protected virtual void LoadPlayerCtril()
    {
        if (this.playerCtril != null) return;
        this.playerCtril = transform.GetComponentInParent<PlayerCtril>();
        Debug.Log(transform.name + ": LoadPlayerCtril", gameObject);
    }    
}
