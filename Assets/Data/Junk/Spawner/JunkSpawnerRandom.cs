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

    
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);

    }    

   protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }    
}
