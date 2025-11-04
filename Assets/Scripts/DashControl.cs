using UnityEngine;

public class DashControl : MonoBehaviour
{
    private int nextThreshold = 5;
    public static int teleportLeft = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && teleportLeft >0) // Sağ tık
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); // Kameranın Z değeri

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0f; // 2D olduğu için z=0 yap

            transform.position = worldPosition;
            teleportLeft--;
        }
        if (PointDestroy.score > nextThreshold)
        {

            teleportLeft++;
            nextThreshold += 5;
            
        }
    }
}
