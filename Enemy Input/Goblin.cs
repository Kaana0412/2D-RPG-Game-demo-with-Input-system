using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : EnemyInput
{
    protected override void Awake()
    {
        base.Awake();
        chaseState = new GoblinChase();
        battleState = new GoblinBattle();
        attackState = new GoblinAttack();
        farAttackState = new GoblinFarAttack();
    }
}

