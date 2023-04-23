using UnityEngine;

public class FunctionalityOnLoad : MonoBehaviour
{
    public bool DestroyOnLoad;
    public bool InvisibleOnLoad;

    private void Start()
    {
        if (InvisibleOnLoad && TryGetComponent(out SpriteRenderer sr))
        {
            sr.enabled = false;
        }

        if (DestroyOnLoad)
            Destroy(gameObject);
    }
}
