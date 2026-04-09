using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    public int damage;
    public float attackRange;
    public float attackRate;

    private void OnTriggerStay2D(Collider2D other)//两个物体范围重合时触发
    {
        other.GetComponent<Character>()?.TakeDamage(this); //other为被攻击的单位
    }
}
