using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public GameObject laser;
    public GameObject indicator;

    private float defaultScale = 0.025f;
    private void Start()
    {
        ActivateBeam();
    }

    public void ActivateBeam()
    {
        
        Color initialColor = indicator.GetComponent<SpriteRenderer>().color;
        initialColor.a = 0.0f;
        indicator.GetComponent<SpriteRenderer>().color = initialColor;
        LeanTween.alpha(indicator, 0.5f, 1.5f).setEase(LeanTweenType.easeInSine);

        Managers.audioManager.PlaySound("laser_charge");
        Utility.InvokeLambda(() => { Managers.audioManager.PlaySound("laser_shoot"); }, 1.4f);

        LeanTween.scaleY(laser, 1, 0.1f).setDelay(1.5f).setOnComplete(() =>
        {
            
            LeanTween.scaleY(laser, defaultScale, 0.2f).setOnComplete(() => { Destroy(gameObject); });
        }).setOnStart(() => 
        {
            laser.GetComponent<BoxCollider2D>().enabled = true;
            laser.GetComponent<SpriteRenderer>().color = Color.white; 
        });
        
    }
}
