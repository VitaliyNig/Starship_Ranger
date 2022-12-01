using UnityEngine;

public class СharacterAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 0f;
    [SerializeField]
    private float offsetPositionZ = 0f;
    public float fireRate;
    public int aimAssistance;

    private void Start()
    {
        float rate = 0.5f - (fireRate * 0.05f);
        InvokeRepeating("BulletCreate", rate, rate);
    }

    private void BulletCreate()
    {
        GameObject bulletGO = Instantiate<GameObject>(bulletPrefab);
        Vector3 bulletPosition = Vector3.zero;
        bulletPosition.z = offsetPositionZ;
        bulletGO.transform.position = this.transform.position + bulletPosition;
        AimAssistance aimAssistanceScript = bulletGO.GetComponent<AimAssistance>();
        aimAssistanceScript.aimAssistance = aimAssistance;
        aimAssistanceScript.enabled = true;
        bulletGO.GetComponent<Rigidbody>().AddForce(0f, 0f, bulletSpeed, ForceMode.Impulse);
    }
}
