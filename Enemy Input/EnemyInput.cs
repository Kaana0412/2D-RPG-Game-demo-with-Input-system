using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public PhysicsSetting physicsSetting;

    [Header("Basic data")]
    public float speed;
    public float currentSpeed;
    public float battleSpeed;
    public Vector2 facingDir;
    public Transform attacker;
    public float hurtForce;

    [Header("Detect")]
    public Vector2 checkSize;
    public float checkDistance;
    public LayerMask attackLayer;
    public Vector2 attackCheckSize;
    public float attackDistence;
    public float farAttackDistence;
    public Transform player;
    public float stopChaseDistence= 0.7f;

    [Header("Timer")]
    public float waitTime;
    public float waitTimeCounter;
    public bool isWait;
    public float lostTime;
    public float lostTimeCounter;
    public float attackCD;
    public float attackCDCounter;
    public float farAttackCD;
    public float farAttackCDCounter;

    [Header("State")]
    public bool isHurt;
    public bool isDead;
    public bool isAttack;

    protected BaseState chaseState;
    protected BaseState battleState;
    protected BaseState currentState;
    protected BaseState attackState;
    protected BaseState farAttackState;

    protected virtual void Awake()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        physicsSetting = GetComponent<PhysicsSetting>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        currentState = chaseState;
        currentState.OnEnter(this);
    }
    private void Start()
    {
        waitTimeCounter = waitTime;
    }

    private void Update()
    {
        facingDir = new Vector2(transform.localScale.x/5,0);

        currentState.LogicUpdate();
        TimeCounter();
    }

    private void FixedUpdate()
    {
        if (!isHurt && !isDead && !isWait &&!isAttack)
            Move();
        currentState.PhysicUpdate();
    }

    private void OnDisable()
    {
        currentState.OnExit();
    }
    public virtual void Move()
    {
        rb.velocity = new Vector2(currentSpeed * facingDir.x * Time.deltaTime , rb.velocity.y);
    }

    public void TimeCounter()
    {
        if (isWait)
        {
            waitTimeCounter -= Time.deltaTime;
            if (waitTimeCounter <= 0)
            {
                isWait = false;
                waitTimeCounter = waitTime;
                transform.localScale = new Vector3(-facingDir.x * 5, 5, 1);
            }
        }

        if (attackCDCounter > 0)
        {
            attackCDCounter -= Time.deltaTime;
        }

        if (!FoundPlayer() && lostTimeCounter > 0)
        {
            lostTimeCounter -= Time.deltaTime;
        }

        if (farAttackCDCounter > 0)
        {
            farAttackCDCounter -= Time.deltaTime;
        }

    }

    public bool FoundPlayer()
    {
        return Physics2D.BoxCast(transform.position,checkSize,0,facingDir,checkDistance,attackLayer);
        
    }

    public bool AttackPlayer()
    {
        return Physics2D.BoxCast(transform.position, attackCheckSize, 0, facingDir, attackDistence, attackLayer);
    }

    public bool FarAttackPlayer()
    {
        return Physics2D.BoxCast(transform.position, attackCheckSize, 0, facingDir, farAttackDistence, attackLayer);
    }


    public void SwitchState(NpcStates state)
    {
        var newState = state switch
        {
            NpcStates.Chase => chaseState,
            NpcStates.Battle => battleState,
            NpcStates.Attack => attackState,
            NpcStates.FarAttack => farAttackState,
            _ => null
        };

        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter(this);
    }

    #region Events
    public void OnTakeDamage(Transform attackerTrans)
    {
        attacker = attackerTrans;
        //面向攻击者
        if (attackerTrans.position.x - transform.position.x < 0)
            transform.localScale =new Vector3(5,5,1);
        if (attackerTrans.position.x - transform.position.x > 0)
            transform.localScale = new Vector3(-5, 5, 1);
        //受击击退
        isHurt = true;
        anim.SetTrigger("Hurt");
        Vector2 dir = new Vector2(transform.position.x - attackerTrans.position.x, 0).normalized;
        rb.velocity = new Vector2(0,rb.velocity.y);
        StartCoroutine(OnHurt(dir));

        if (isAttack)
        {
            isAttack =false;
            SwitchState(NpcStates.Battle);
        }
        
    }

    private IEnumerator OnHurt(Vector2 dir)
    {
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse); 
        yield return new WaitForSeconds(0.45f); 
        isHurt = false;
    }

    public void OnDie()
    {
        gameObject.layer = 2;
        anim.SetTrigger("Dead");
        isDead = true;
    }

    public void AttackOver()
    {
        isAttack = false;
        if (!isDead)
            SwitchState(NpcStates.Battle);
    }

    public void FaceToPlayer()
    {
        if (player.position.x < transform.position.x)
            transform.localScale = new Vector3(-5,5,1);
        else if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(5,5,1);
    }
    public float DistanceToPlayer()
    {
        return Mathf.Abs(player.position.x - transform.position.x);
    }

    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
