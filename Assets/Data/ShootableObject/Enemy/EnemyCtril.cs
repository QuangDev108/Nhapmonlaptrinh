using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtril : ShootableObjectCtril
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
