using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    MeshRenderer meshRenderer;

    [SerializeField]
    private float blinkIntensity;
    [SerializeField]
    private float blinkDuration;
    private float blinkTimer;

    public void SetDamageParameter(GameObject go)
    {
        meshRenderer = go.GetComponent<MeshRenderer>();
    }

    public void TakeDamage()
    {
        blinkTimer = blinkDuration;
    }

    private void Update()
    {
        if (meshRenderer)
        {
            if (meshRenderer.materials[1].color != Color.black)
            {
                blinkTimer -= Time.deltaTime;
                float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
                float intensity = (lerp * blinkIntensity);
                meshRenderer.materials[1].color = Color.white * intensity;
            }
        }
    }
}