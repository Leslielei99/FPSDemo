using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Idle, Patrol, Chase, React, Attack
public class IdleState : IState
{
    private FSM manager;
    private Parameter parameter;
    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("IdleNormal");
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        if (parameter.isGetHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if ((manager.transform.position - parameter.Player.position).magnitude < 10f)
        {
            manager.TransitionState(StateType.React);
        }
    }
}
public class PatrolState : IState
{
    private FSM manager;
    private Parameter parameter;
    public PatrolState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
}
public class ChaseState : IState
{
    private FSM manager;
    private Parameter parameter;
    public ChaseState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("RunFWD");
    }
    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        if (parameter.isGetHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        manager.FlipTo();
        parameter.agent.SetDestination(parameter.Player.position);
  //      manager.transform.position = Vector3.MoveTowards(manager.transform.position,
  //parameter.Player.position, parameter.chaseSpeed * Time.deltaTime);
        if ((parameter.Player.position - manager.transform.position).magnitude > 10f)
        {
            manager.TransitionState(StateType.Idle);
        }
        if ((parameter.Player.position - manager.transform.position).magnitude < 3)
        {
            manager.TransitionState(StateType.Attack);
        }
    }

}
public class ReactState : IState
{
    private FSM manager;
    private Parameter parameter;
    private AnimatorStateInfo info;
    public ReactState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("SenseSomethingST");
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        manager.FlipTo();
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 0.95f)
        {
            manager.TransitionState(StateType.Chase);
        }
    }
}
public class AttackState : IState
{
    private FSM manager;
    private Parameter parameter;
    private AnimatorStateInfo info;
    public AttackState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Attack02");
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if (parameter.isGetHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if ((parameter.Player.position - manager.transform.position).magnitude > 3 && info.normalizedTime >= 0.95f)
        {
            manager.TransitionState(StateType.Chase);
        }
    }
}
public class HitState : IState
{
    private FSM manager;
    private Parameter parameter;

    private float tmp_time = 0;
    private AnimatorStateInfo info;
    public HitState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("GetHit");
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        if (parameter.Health <= 0)
        {
            manager.TransitionState(StateType.Die);
        }
        if (parameter.Health <= 4 && parameter.isTu)
        {
            manager.TransitionState(StateType.Defend);
        }
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        //tmp_time += Time.deltaTime;
        if (info.normalizedTime >= 0.95f)
        {
            parameter.isGetHit = false;
            manager.TransitionState(StateType.Chase);
        }
    }
}
public class DieState : IState
{
    private FSM manager;
    private Parameter parameter;
    private AnimatorStateInfo info;
    public DieState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        Controller.Instance().DestoryEnemy();
        parameter.animator.Play("Die");
    }
    public void OnExit()
    {

    }
    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 0.95f)
        {
            manager.DestoryGameobject();
        }
    }
}
public class DefendState : IState
{
    private FSM manager;
    private Parameter parameter;
    private AnimatorStateInfo info;
    private float tmp_ime;
    private float tmp_time2;
    public DefendState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Defend");
        tmp_time2 = tmp_ime;
    }
    public void OnExit()
    {

    }
    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if (parameter.isGetHit && info.normalizedTime >= 0.95f)
        {
            manager.TransitionState(StateType.DefendHit);
        }

        tmp_ime += Time.deltaTime;
        if (tmp_ime > (tmp_time2 + 2) && !parameter.isGetHit)
        {
            parameter.Health++;
            tmp_time2 = tmp_ime;
        }
        if (tmp_ime > 6 && !parameter.isGetHit)
        {
            manager.TransitionState(StateType.Idle);
            tmp_ime = 0;
        }
    }
}
public class DefendHitState : IState
{
    private FSM manager;
    private Parameter parameter;
    private AnimatorStateInfo info;
    public DefendHitState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("DefendGetHit");
    }
    public void OnExit()
    {

    }
    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if (parameter.Health <= 0)
        {
            manager.TransitionState(StateType.Die);
        }
        // if (info.normalizedTime >= 0.95f)
        // {
        //     manager.TransitionState(StateType.Defend);
        //     parameter.isGetHit = false;
        // }
    }
}
