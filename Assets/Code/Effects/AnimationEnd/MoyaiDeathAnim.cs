using UnityEngine;

public class MoyaiDeathAnim : AnimationEndEffect
{
    public override void SetAnimationEnd(string animationName)
    {
        GetComponent<Animator>().SetTrigger("death");
        GetComponent<BoxCollider2D>().enabled = false;
        base.SetAnimationEnd(animationName);
    }

    public override void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
