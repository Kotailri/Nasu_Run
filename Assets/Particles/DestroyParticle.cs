
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (!ps.isPlaying)
        {
            Destroy(gameObject);
        }
    }

}
