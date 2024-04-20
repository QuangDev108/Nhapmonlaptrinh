using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtril : QuangMonoBehaviour
{
    private static GameCtril instance;
    public static GameCtril Instance { get => instance; }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    protected override void Awake()
    {
        base.Awake();
        if (GameCtril.instance != null) Debug.LogError("Only 1 GameManager allow to exist");
        GameCtril.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }
    
    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameCtril.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }    


}
