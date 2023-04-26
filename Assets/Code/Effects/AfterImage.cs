using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    void Start()
    {
        Color initialColor = GetComponent<SpriteRenderer>().color;
        initialColor.a = 0.5f;
        GetComponent<SpriteRenderer>().color = initialColor;
        LeanTween.alpha(gameObject, 0f, 0.3f).setOnComplete(() => { Destroy(gameObject); });
    }
}
