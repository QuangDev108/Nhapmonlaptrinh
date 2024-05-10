using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtril : QuangMonoBehaviour
{
    private static MapCtril instance;
    public static MapCtril Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MapCtril.instance != null) Debug.LogError("Only 1 MapManager allow to exist");
        MapCtril.instance = this;
    }
}
