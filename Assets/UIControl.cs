using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text PointShowcase;
    public static int pointPrevious = 0;
    public Image PointCountdown;
    public TextMeshProUGUI PointHolder;
    public PointDestroy pointDestroy;
    public PlayerMovement playerMovement;

    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        int pointCurrent = GameObject.FindGameObjectsWithTag("Points").Length;
        int delta = pointPrevious - pointCurrent;
        if (delta == 1)
        {
            PointCountdown.fillAmount += 0.1f;
        }
        if (delta == 2)
        {
            PointCountdown.fillAmount += 0.2f;
        }
        if (delta == 3)
        {
            PointCountdown.fillAmount += 0.3f;
        }
        if (delta == 4)
        {
            PointCountdown.fillAmount += 0.4f;
        }

       
        if (pointCurrent > pointPrevious)
        {
            PointCountdown.fillAmount -= 0.1f;
        }

        PointHolder.text = "Point: " + PointDestroy.score;

        PointShowcase.text = "Total score is: " + PointDestroy.score + " Teleport left is: " + DashControl.teleportLeft + "\n" +
        "Speed is: " + playerMovement.movementSpeed;
        
        pointPrevious = pointCurrent;
    }
}
