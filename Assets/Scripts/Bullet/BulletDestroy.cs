using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
