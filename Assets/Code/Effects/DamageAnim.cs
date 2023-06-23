using UnityEngine;

public class DamageAnim : MonoBehaviour
{
    public Color damageCol;
    
    private Color defaultCol;
    private SpriteRenderer spriteRenderer;
    private readonly float flashTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultCol = spriteRenderer.color;
    }

    public void SetDefaultCol(Color col)
    {
        defaultCol = col;
        spriteRenderer.color = defaultCol;
    }

    public void PlayDamageAnim()
    {
        spriteRenderer.color = damageCol;
        Utility.InvokeLambda(() =>
        {
            if (spriteRenderer != null)
                spriteRenderer.color = defaultCol;
        }, flashTime);
    }
}
