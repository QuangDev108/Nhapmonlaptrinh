using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class BulletSpawner : Spawner
{
    protected static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    public static string bulletOne = "Bullet_1";

    protected override void Awake()
    {
        base.Awake();

        if (BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow  to exits");
        BulletSpawner.instance = this;
    }
}
