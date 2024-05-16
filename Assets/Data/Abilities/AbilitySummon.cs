using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner; 

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
        Transform spawnPos = this.abilites.AbilityObjectCtril.SpawnPoints.GetRandom();

        Transform minionPrefabs = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefabs, spawnPos.position, spawnPos.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
    }    
}
