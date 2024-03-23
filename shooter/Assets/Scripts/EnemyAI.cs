using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public PlayerController player;
    public List<Transform> PatrolPoints;
    public float ViewAngle;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    public float Damage = 30;
    private PlayerHealth _playerHealth;
    public Animator animator;
    public EnemyHealth _enemyHealth;
    public float attackDistance = 0.2f;

    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }

    private void Start()
    {
        InitializeComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitializeComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();

    }

    private void Update()
    {
        NoticePlayerUpdate();
        PatrolUpdate();
        ChaseUpdate();
        AttackUpdate();
    }

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        if (!_playerHealth.IsAlive()) return;

        var direction = player.transform.position - transform.position;

        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("attack");
            }
        }
    }
    public void AttackDamage()
    {
        if (!_isPlayerNoticed) 
            return;

        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance + attackDistance) 
            return;

        _playerHealth.DealDamage(Damage);
    }
}
