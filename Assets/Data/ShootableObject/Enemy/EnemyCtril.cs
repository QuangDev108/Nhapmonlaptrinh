using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtril : AbilityObjectCtril
{
        protected override string GetObjectTypeString()
        {
            return ObjectType.Enemy.ToString();
        }
}

