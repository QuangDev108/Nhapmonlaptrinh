using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;

    protected void Reset()
    {
        this.LoadComponents();
    }

     void Awake()
    {
        //this.HidePrefab();
    }

    protected virtual void LoadComponents()
    {
        this.LoadPrefab();
    }   
    
    protected virtual void LoadPrefab()
    {
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefab();
    }    

    protected virtual void HidePrefab()
    {
        foreach(Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }    
    }    
}
