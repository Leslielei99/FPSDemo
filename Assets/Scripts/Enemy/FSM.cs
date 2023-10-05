using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public enum StateType
{
    Idle,
    Patrol,//巡逻
    Chase,//追逐
    React,//反应
    Hit,
    Attack,
    Die,
    Defend,
    DefendHit
}
[Serializable]
public class Parameter
{
    public int Health;
    public float moveSpeed;
    public float chaseSpeed;
    public Transform Player;
    public Animator animator;
    public NavMeshAgent agent;
    private bool inViews;
    public bool isGetHit;
    public bool isTu;
}
public class FSM : MonoBehaviour
{
    public Parameter parameter;
    public Transform Player;
    private IState currentState;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    private void Start()
    {
        parameter.Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.Hit, new HitState(this));
        states.Add(StateType.Die, new DieState(this));
        states.Add(StateType.Defend, new DefendState(this));
        states.Add(StateType.DefendHit, new DefendHitState(this));
        TransitionState(StateType.Idle);
        parameter.animator = GetComponent<Animator>();
        parameter.agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        currentState.OnUpdate();
    }
    public void TransitionState(StateType type)
    {
        if (currentState! != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }
    public void FlipTo()
    {
        //transform.LookAt(Player);
        Vector3 direction = Player.position - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        Quaternion.LookRotation(direction), 0.5f);
    }
    public void DestoryGameobject()
    {
        Destroy(this.gameObject, 1);
    }
    public void StartWait()
    {
        StartCoroutine(WaitForLook());
    }
    IEnumerator WaitForLook()
    {
        yield return new WaitForSeconds(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            parameter.isGetHit = true;
            Debug.Log("受到攻击了");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            parameter.isGetHit = false;
        }
    }
}
