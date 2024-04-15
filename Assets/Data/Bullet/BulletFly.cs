using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float movespeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void Update()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}
