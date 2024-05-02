using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtril : QuangMonoBehaviour
{
    private static PlayerCtril instance;
    public static PlayerCtril Instance => instance;

    [SerializeField] protected ShipCtril currentShip;
    public ShipCtril CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtril.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtril.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ": LoadPlayerPickup", gameObject);
    }    
}
