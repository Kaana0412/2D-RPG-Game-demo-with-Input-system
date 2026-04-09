
public abstract class BaseState
{
    protected EnemyInput currentEnemy;
    public abstract void OnEnter(EnemyInput enemy);
    public abstract void LogicUpdate();
    public abstract void PhysicUpdate();
    public abstract void OnExit();
}
