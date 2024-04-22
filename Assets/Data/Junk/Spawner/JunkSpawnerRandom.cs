using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : QuangMonoBehaviour
{
    [Header("Junk Random")]
    [SerializeField] protected JunkSpawnerCtril junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtril();
    }

    protected virtual void LoadJunkCtril()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtril>();
        Debug.Log(transform.name + ": junkCtrl", gameObject);
    }    

    protected override void Start()
    {
       // this.JunkSpawning();
    }
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);

        Invoke(nameof(this.JunkSpawning), 1f);
    }    

   
}
