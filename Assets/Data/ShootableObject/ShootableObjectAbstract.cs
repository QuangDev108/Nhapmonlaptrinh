using UnityEngine;

public abstract class ShootableObjectAbstract : QuangMonoBehaviour
{

    [SerializeField] protected ShootableObjectCtril shootableObjectCtril;
    public ShootableObjectCtril ShootableObjectCtril => shootableObjectCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtril();
    }
    protected virtual void LoadShootableObjectCtril()
    {
        if (this.shootableObjectCtril != null) return;
        this.shootableObjectCtril = transform.parent.GetComponent<ShootableObjectCtril>();
        Debug.Log(transform.name + ": LoadShootableObjectCtril", gameObject);
    }    
 
}
