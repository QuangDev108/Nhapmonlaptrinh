using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : QuangMonoBehaviour
{
    [Header("Base Ability")]

    [SerializeField] protected Abilities abilites;
    public Abilities Abilites => abilites;

    [SerializeField] protected float timer = 2f; 
    [SerializeField] protected float delay = 2f; 
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Update()
    {
       
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilitesl();
    }
    protected virtual void LoadAbilitesl()
    {
        if (this.abilites != null) return;
        this.abilites = transform.parent.GetComponent<Abilities>();
        Debug.Log(transform.name + ": LoadAbilitesl", gameObject);
    }
    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }    

    public virtual void Active()
    {
        this.isReady = false;
        this.timer = 0;
    }    
}
