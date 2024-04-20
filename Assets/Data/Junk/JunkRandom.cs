using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : QuangMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtril junkCtril;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtril();
    }

    protected virtual void LoadJunkCtril()
    {
        if (this.junkCtril != null) return;
        this.junkCtril = GetComponent<JunkSpawnerCtril>();
        Debug.Log(transform.name + ": LoadJunkRandom", gameObject);
    }    

    protected override void Start()
    {
        this.JunkSpawning();
    }    

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkCtril.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkCtril.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);

        Invoke(nameof(this.JunkSpawning), 1f);
    }    
}
