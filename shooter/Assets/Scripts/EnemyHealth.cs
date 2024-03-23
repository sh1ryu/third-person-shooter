using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public float Value = 100;

    public PlayerProgress playerProgress;
    public Explosion explosionPrefab;

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    public bool IsAlive()
    {
        return Value > 0;
    }

    public void DealDamage(float damage)
    {
        if (playerProgress != null)
        {
            playerProgress.AddExperience(damage);
        }

        Value -= damage;
        if (Value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }
    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
