using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected Transform mainCam;
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }
    protected override bool CanDespawn()
    {
        //ktra kc tu vi tri vien dan den vi tri camera
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}
