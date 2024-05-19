using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjModifyAbtract : QuangMonoBehaviour
{
    [Header("Modify")]
    [SerializeField] protected ShootableObjectCtril shootableObjectCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtril();
    }

    protected virtual void LoadShootableObjectCtril()
    {
        if (this.shootableObjectCtril != null) return;
        this.shootableObjectCtril = transform.GetComponent<ShootableObjectCtril>();
        Debug.Log(transform.name + ": LoadShootableObjectCtril", gameObject);
    }    
}
