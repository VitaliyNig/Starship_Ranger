using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeAreaFix : MonoBehaviour
{
    private void Awake()
    {
        if (Screen.safeArea.height != Screen.height)
        {
            Canvas[] canvasObjects = this.GetComponentsInChildren<Canvas>();
            foreach(var co in canvasObjects)
            {
                co.transform.position -= new Vector3(0f, -50f, 0f);
            }
        }
    }
}
