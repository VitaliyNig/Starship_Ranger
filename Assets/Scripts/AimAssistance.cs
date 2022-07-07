using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistance : MonoBehaviour
{
    public int aimAssistance;
    private Vector3 sizeAssistance;
    private Transform thisTransform;
    private int layerMask;

    private void Start()
    {
        float forceAssistance = (0.5f * aimAssistance);
        sizeAssistance = new Vector3(forceAssistance, forceAssistance, forceAssistance);
        layerMask = (1 << 10);
        thisTransform = this.transform;
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapBox(thisTransform.position, sizeAssistance, thisTransform.localRotation, layerMask);
        if (colliders != null)
        {
            foreach (var c in colliders)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, c.transform.position, 0.1f);
            }
        }
    }
}