using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class SliderHP : BaseSlider
{
    [Header("Slider HP")]
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float curentHP = 70;

    protected override void FixedUpdate()
    {
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = this.curentHP / this.maxHP;
        this.slider.value = hpPercent;
    }    
    protected override void OnChanged(float newValue)
    {
       // Debug.Log("newValue: " + newValue);
    }    

    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }

    public virtual void SetCurrentHP(float currentHP)
    {
        this.curentHP = currentHP;
    }
    
}
