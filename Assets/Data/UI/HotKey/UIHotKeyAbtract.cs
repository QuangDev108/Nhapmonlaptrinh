using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyAbtract : QuangMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtril hotKeyCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIKeyCtrl();
    }

    protected virtual void LoadUIKeyCtrl()
    {
        if (this.hotKeyCtril != null) return;
        this.hotKeyCtril = transform.parent.GetComponent<UIHotKeyCtril>();
        Debug.Log(transform.name + ": LoadUIKeyCtrl", gameObject);
    }    
}
