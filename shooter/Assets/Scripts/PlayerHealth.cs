using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Value = 100;
    public RectTransform valueRectTransform;

    private float _maxValue;
    public GameObject gameplayUI;
    public GameObject gamepOverScreen;
    public Animator animator;

    private void Start()
    {
        _maxValue = Value;
        DrawHealthBar();
    }

    public bool IsAlive()
    {
        return Value > 0;
    }

    public void DealDamage(float damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        Value += amount;
        Value = Mathf.Clamp(Value, 0, _maxValue);
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(Value / _maxValue, 1);
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gamepOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("death");
    }
}
