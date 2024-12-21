using System.Collections;
using System.Collections.Generic;
using Enemies.StateMachine;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class ChaseState : IEnemyState
{
    private EnemyStateMachine stateMachine;
    private Player player;
    private NavMeshAgent agent;
    public void EnterState(EnemyStateMachine context, Enemy enemy)
    {
        stateMachine = context;
        player = stateMachine.player;
        agent = stateMachine.GetComponent<NavMeshAgent>();
    }

    public void UpdateState()
    {
        agent.SetDestination(player.transform.position);
        if(agent.isStopped)
        {
            stateMachine.SwitchState(stateMachine.attackState);
        }
    }

    public void PhysicsUpdateState()
    {

    }

    public void ExitState()
    {

    }
}
