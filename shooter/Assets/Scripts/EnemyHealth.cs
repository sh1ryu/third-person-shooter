using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Value = 100;

    public PlayerProgress playerProgress;
    public Explosion explosionPrefab;

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
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
            Destroy(gameObject);
        }
    }
}
