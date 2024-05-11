using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtril shootableObjectCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.shootableObjectCtril != null) return;
        this.shootableObjectCtril = transform.parent.GetComponent<ShootableObjectCtril>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.shootableObjectCtril.Despawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtril.ShootableObject.dropList, dropPos, dropRot);
    }
    protected virtual void OnDeadFX()
    {
        string fxname = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxname, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
    public override void Reborn()
    {
        this.hpMax = this.shootableObjectCtril.ShootableObject.hpMax;
        base.Reborn();

    }
}
