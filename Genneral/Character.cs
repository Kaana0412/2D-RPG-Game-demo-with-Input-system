using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public float invulnerableDuration;
    private float invulnerableTime;
    public bool invulnerable;
    public UnityEvent<Character> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDead;
    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthChange?.Invoke(this);
    }

    private void Update()
    {
        if (invulnerable)
        {
            invulnerableTime -= Time.deltaTime;//无敌时间自动减少
            if(invulnerableTime <= 0 )
            {
                invulnerable = false;//重置
            }
        }
    }
    public void TakeDamage(Attack attacker)//受击时
    {
        if (invulnerable) 
            return;//短时间内只触发一次伤害

        if(currentHealth - attacker.damage >0)
        { 
            currentHealth -= attacker.damage;//血量-攻击者的攻击力
            TriggerInvulnerable();//触发受击无敌
            OnTakeDamage?.Invoke(attacker.transform);//Unity事件启动
        }
        else
        {
            currentHealth = 0;
            OnDead?.Invoke();
        }

        OnHealthChange?.Invoke(this);
    }

    public void TriggerInvulnerable()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            invulnerableTime = invulnerableDuration;//重置受击无敌时间
        }
    }
}
