using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int hp;

    public virtual void TakeDamage(int damage)
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
