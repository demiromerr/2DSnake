using System.Collections;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject mushroom;
    public GameObject Player;
    public Collider2D MushroomCollider;
    public Collider2D PlayerCollider;
    private bool keepSpawning = true;
    float spawnInterval = 1.3f;
    public WallHit wallHit;
    public Transform playerPos;

    private float spawnDistance = 2f;
    

    void Start()
    {
        StartCoroutine(SpawnRoutineMushroom());
        
    }
    IEnumerator SpawnRoutineMushroom()
    {
        while(keepSpawning) 
        {
            Vector3 randomPosition;                                     // randomPosition adında bir vektör tanımladım
            do
            {
                float randomX2 = Random.Range(-14f, 14f);
                float randomY2 = Random.Range(-10f, 10f);
                randomPosition = new Vector3(randomX2, randomY2, 0f);   // bu bölgede randomPosition'ı oluşturmuş oldum. 
            }
            while (Vector3.Distance(randomPosition, playerPos.position) < spawnDistance);   // Yukarıda oluşan randomPosition ile karakterin konumu arasındaki mesafe ölçülür.
                                                                                            // Bu mesafe daha önce belirtilen spawnDistance değerinden küçük ise alt satırlar
                                                                                            // çalışır.
    
            Instantiate(mushroom, randomPosition, Quaternion.identity);                     
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    void Update()
    {
        
        if (wallHit.gameContinue == false)
        {
            keepSpawning = false;
        }
    }
}
