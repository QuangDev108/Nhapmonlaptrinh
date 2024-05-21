using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ObjAppearingWithoutShoot : ShootableObjectAbstract,IObjAppearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjAppearing objAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();
    }
    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null) return;
        this.objAppearing = GetComponentInChildren<ObjAppearing>();
        Debug.Log(transform.name + ": LoadObjShooting", gameObject);
    }

    protected virtual void RegisterAppearEvent()
    {
        this.objAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtril.ObjShooting.gameObject.SetActive(false);
        this.shootableObjectCtril.ObjLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtril.ObjShooting.gameObject.SetActive(true);
        this.shootableObjectCtril.ObjLookAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtril.Spawner.Hold(transform.parent);
    }
}

