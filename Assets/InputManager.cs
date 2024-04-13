using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] public Vector3 mouseworldPos;

     void Awake()
    {
        InputManager.instance = this;
    }
    void FixedUpdate()
    {
        this.GetMousePos();
    }


    protected virtual void GetMousePos()
    {
        this.mouseworldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
