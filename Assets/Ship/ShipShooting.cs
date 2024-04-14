using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.5f;
    [SerializeField] protected float shootTimer = 0;
    [SerializeField] protected Transform bulletPrefab;


    void Update()
    {
        this.IsShooting();
    }
    protected void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;    

        Vector3 spawnpos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = Instantiate(bulletPrefab, spawnpos, rotation);
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shooting");
    }    

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }    
}
