using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private int hp;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnDeath();
        }
    }

    protected void SetHealth(int hp_)
    {
        hp = hp_;
    }

    public abstract void OnDeath(); 
}
