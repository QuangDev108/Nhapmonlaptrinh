using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHp : BaseTexts
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP(); 
    }

    protected virtual void UpdateShipHP()
    {
       int hpMax = PlayerCtril.Instance.CurrentShip.DamageReceiver.HPMax;
        int hp = PlayerCtril.Instance.CurrentShip.DamageReceiver.HP;

        this.text.SetText(hp + " / " + hpMax);
    }    
}
