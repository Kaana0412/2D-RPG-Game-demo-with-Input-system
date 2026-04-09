using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : EnemyInput
{
    protected override void Awake()
    {
        base.Awake();
        chaseState = new MushroomChase();
        battleState = new MushroomBattle();
        attackState = new MushroomAttack();
    }
}
