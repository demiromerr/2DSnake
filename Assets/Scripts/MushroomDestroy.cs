using UnityEngine;

public class MushroomDestroy : MonoBehaviour
{
    
    void Start()
    {

        Destroy(gameObject, 7f );
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Blade"))
        {
            PointDestroy.score -= 1;
          
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PointDestroy.score -= 2;        
        }
        Destroy(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
