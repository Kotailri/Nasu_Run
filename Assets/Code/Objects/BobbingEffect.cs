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
            .setRepeat(-1)
            .setOnUpdate(OnUpdate);
    }

    void OnUpdate(float value)
    {
        Vector3 newPosition = new Vector3(transform.position.x, originalPosition.y, transform.position.z);
        newPosition.y = value;
        transform.position = newPosition;
    }
}
