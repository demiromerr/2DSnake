using UnityEngine;
using UnityEngine.SceneManagement;

public class WallHit : MonoBehaviour
{
    public bool gameContinue = true;
    public GameObject Player;
    public Spawner2D spawner2D;
    void Start()
    {
        
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameContinue = false;
            Spawner2D.Instance.GameEnd();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameContinue && Input.GetKeyDown(KeyCode.R))
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (gameContinue == false)
        {
            Destroy(Player.gameObject);
        }
    }
}
