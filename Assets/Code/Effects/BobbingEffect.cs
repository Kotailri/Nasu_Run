using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float duration = 1f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;

        LeanTween.moveY(gameObject, originalPosition.y + amplitude, duration / 2f)
            .setEase(LeanTweenType.easeOutSine)
            .setLoopPingPong()
            .setRepeat(-1);
    }
}
