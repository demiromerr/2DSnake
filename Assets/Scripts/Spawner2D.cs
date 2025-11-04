



using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner2D : MonoBehaviour
{
    public static Spawner2D Instance;
    public GameObject point;
    public GameObject Player;
    public Collider2D PlayerCollider;
    public Collider2D PointCollider;
    public bool keepSpawning = true;
    float spawnInterval = 2f;
    public WallHit wallHit;
    private int maxRecordedPoint;
    public Text Restart;
    public Text MaxRecord;
    public PointDestroy pointDestroy;
    private bool scoreChecked = true;
    public Button resetButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        Restart.gameObject.SetActive(false);
        PointDestroy.score = 0;
        DashControl.teleportLeft = 0;
        resetButton.interactable = false;
    }
    
    
    
    void Start()
    {
        StartCoroutine(SpawnRoutinePoint());
        

        maxRecordedPoint = PlayerPrefs.GetInt("MaxRecordedPoint",0);
        MaxRecord.text = "Rekor: " + maxRecordedPoint;
    }
    public void scoreReset()
    {
        PlayerPrefs.SetInt("MaxRecordedPoint", 0);
        PlayerPrefs.Save();
    }
    IEnumerator SpawnRoutinePoint()
    {
        while(keepSpawning) 
        {
        float randomX = Random.Range(-14f, 14f);
        float randomY = Random.Range(-10f, 10f);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
        Instantiate(point,randomPosition,Quaternion.identity);
        spawnInterval = spawnInterval - 0.03f;
            if (spawnInterval < 0.8f)
            {
                spawnInterval = 0.8f;
            }
            
        yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void GameEnd()
    {
        resetButton.interactable = true;
        keepSpawning = false;
        wallHit.gameContinue = false;
        Restart.gameObject.SetActive(true);
        if (PointDestroy.score > maxRecordedPoint)
        {
        
        maxRecordedPoint = PointDestroy.score;
        PlayerPrefs.SetInt("MaxRecordedPoint", maxRecordedPoint);
        MaxRecord.text = "Rekor: " + maxRecordedPoint;
        Restart.text = "NEW RECORD! = " + PointDestroy.score + "\n" +
                       "TO START AGAIN PRESS 'R' ";
        }
        else
        { 
        Restart.text = "YOUR POINT IS = " + PointDestroy.score + "\n" +
                       "TO START AGAIN PRESS 'R' ";
        }

    }


    



    void Update()
    {
        int pointCount = GameObject.FindGameObjectsWithTag("Points").Length;

        if (pointCount >= 10  && scoreChecked)

        {   
            Destroy(Player.gameObject);
            GameEnd();
            keepSpawning = false;
            scoreChecked = false;

        }
        if (wallHit.gameContinue == false)
        {
            
            Restart.gameObject.SetActive(true);
        }
        
        

        
        
    }
}
        

        