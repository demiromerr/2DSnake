using UnityEngine;

public class PointDestroy : MonoBehaviour
{

    public static int score = 0;
    public static int destroyedPoints = 0;



    void Start()
    {
        
        
    }
    



    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Blade"))
        {
            score += 2;
            destroyedPoints += 1;

            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            score += 1;
            destroyedPoints += 1;
            
        }

        Destroy(gameObject);
        
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
