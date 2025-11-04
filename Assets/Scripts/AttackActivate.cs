using System.Collections;
using UnityEngine;

public class AttackActivate : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject attackEffect;
    public float cooldownDuration = 1f;
    private bool canActivate = true;
    private int nextThreshold = 5;
    
    void Start()
    {


    }


    void Update()
    {
        if (PointDestroy.score >= nextThreshold)
        {
            attackArea.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            nextThreshold += 5;
            

        }

        if (Input.GetMouseButtonDown(0) && canActivate)
        {
            attackArea.SetActive(true);
            attackEffect.SetActive(true);
            StartCoroutine(DeactivateAfterDelay());
        }

    }
    IEnumerator DeactivateAfterDelay()
    {
        canActivate = false;
        yield return new WaitForSeconds(0.25f);
        attackArea.SetActive(false);
        attackEffect.SetActive(false);
        yield return new WaitForSeconds(cooldownDuration);
        canActivate = true;                    
    }

}
