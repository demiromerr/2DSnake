
using UnityEngine;

public class SpectatorLook : MonoBehaviour
{
    public Transform target;
    public WallHit wallHit;
    void Start()
    {
        
    }


    void Update()
    {
        if (target != null)
        {
            Vector3 look = target.position - transform.position;
            float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg + 90;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
        
    }
}
