using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtril bulletCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtril();
    }

    protected virtual void LoadBulletCtril()
    {
        if (this.bulletCtril != null) return;
        this.bulletCtril = transform.parent.GetComponent<BulletCtril>();
        Debug.Log(transform.name + ": LoadBulletCtril", gameObject);
    }
    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        bulletCtril.BulletDespawn.DespawnObject();
    }
}
