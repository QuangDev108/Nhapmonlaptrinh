using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Abilities : QuangMonoBehaviour
{
    [Header("Abilites")]
    [SerializeField] protected AbilityObjectCtril abilityObjectCtril; 
    public AbilityObjectCtril AbilityObjectCtril => abilityObjectCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjectCtril();
    }
    protected virtual void LoadAbilityObjectCtril()
    {
        if (this.abilityObjectCtril != null) return;
        this.abilityObjectCtril = transform.parent.GetComponent<AbilityObjectCtril>();
        Debug.Log(transform.name + ": LoadAbilityObjectCtril", gameObject);
    }
}
