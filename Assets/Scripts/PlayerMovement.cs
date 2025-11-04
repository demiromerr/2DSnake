

using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float rotationSpeed = 180f;
        void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Points")
        {
            movementSpeed += 0.05f;

        }
        if (collision.gameObject.tag == "mushroom")
        {
            float randomZ = Random.Range(0f, 360f);
            transform.rotation = Quaternion.Euler(0, 0, randomZ);
        }

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        

        
    }
    
}
