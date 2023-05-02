using UnityEngine;

public abstract class AnimationEndEffect : MonoBehaviour
{
    protected Animator animator;
    public abstract void OnAnimationEnd();

    private void Start()
    {
        if (GetComponent<Animator>() == null)
        {
            Utility.PrintWarn("Animator component not found on object " + gameObject.name);
        }
    }

    public virtual void SetAnimationEnd(string animationName)
    {
        if (TryGetComponent(out animator))
        {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                if (clip.name == animationName)
                {
                    Invoke(nameof(OnAnimationEnd), clip.length);
                    return;
                }
            }
            Utility.PrintWarn(gameObject.name + " could not find animation " + animationName);
        }
    }
}
