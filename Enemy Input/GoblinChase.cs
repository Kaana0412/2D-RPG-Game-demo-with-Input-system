using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChase : BaseState
{

    public override void OnEnter(EnemyInput enemy)
    {
        currentEnemy = enemy;
        currentEnemy.currentSpeed = 0;
        currentEnemy.transform.localScale = new Vector3(-5, 5, 1);
    }
    public override void LogicUpdate()
    {

        if (currentEnemy.FoundPlayer())
        {
            currentEnemy.SwitchState(NpcStates.Battle);
        }

    }
    public override void PhysicUpdate()
    {

    }

    public override void OnExit()
    {
        currentEnemy.anim.SetBool("isMove", false);
    }

}
