using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : QuangMonoBehaviour
{
    public virtual void Active(AbilitiesCode abilitiesCode)
    {
        Debug.Log("abilitiesCode: " +  abilitiesCode.ToString());
    }    
}
