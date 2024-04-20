using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : QuangMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletCtril bulletCtril;
    public BulletCtril BulletCtril { get => bulletCtril; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.bulletCtril != null) return;
        this.bulletCtril = transform.parent.GetComponent<BulletCtril>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }    

}
