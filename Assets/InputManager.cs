using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mouseworldPos;
    public Vector3 MouseworldPos { get => mouseworldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring {  get => onFiring; }

     void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow  to exits");
        InputManager.instance = this;
    }

     void Update()
    {
        this.GetMouseDown();
    }
    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseworldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }    
}
