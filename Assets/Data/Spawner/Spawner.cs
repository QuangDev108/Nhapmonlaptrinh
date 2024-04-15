using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : QuangMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;

    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefab();
    }

    protected virtual void LoadPrefab()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefab();
        Debug.Log(transform.name + ": LoadPrefab", gameObject);
    }

    protected virtual void HidePrefab()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnpos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found! " + prefabName);
            return null;
        }

        Transform newPrefab = Instantiate(prefab, spawnpos, rotation);
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == prefabName)  return prefab;
        }
        return null;
    }
}

