using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : QuangMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtril shootableObjectCtril;
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
        this.LoadFollowTarget();
    }

    protected virtual void LoadSlider()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }    

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }    

    protected virtual void HPShowing()
    {
        if(this.shootableObjectCtril == null) return;

        float hp = this.shootableObjectCtril.DamageReceiver.HP;
        float maxHp = this.shootableObjectCtril.DamageReceiver.HPMax;

        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetMaxHP(maxHp);
    }    

    public virtual void SetObjectCtril(ShootableObjectCtril shootableObjectCtril)
    {
        this.shootableObjectCtril = shootableObjectCtril;
    }   
    
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }    
}
