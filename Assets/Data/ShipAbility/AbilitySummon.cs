using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner Spawner; 

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        this.Summon();
    }   
    
    protected virtual void Summon()
    {
        Transform minionPrefabs = this.Spawner.RandomPrefab();
        Transform minion = this.Spawner.Spawn(minionPrefabs,transform.position,transform.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
    }    
}
