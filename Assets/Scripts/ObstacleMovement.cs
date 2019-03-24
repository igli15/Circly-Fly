using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 0.2f;

    private bool thrustUp;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        thrustUp = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (thrustUp)
        {
            Debug.Log("thrusitng up");
            ThrustUp();
        }
        else
        {
            Debug.Log("thrusting down");
            ThrustDown();
        }
    }

    private void ThrustUp()
    {
        rb.velocity = transform.up * speed;
        Invoke("SetThrustToFalse", 2);
    }

    private void ThrustDown()
    {
        rb.velocity = -transform.up * speed;


        Invoke("SetThrustToTrue", 4);
    }

    private void SetThrustToTrue()
    {
        thrustUp = true;
        speed = Random.Range(0.5f, 1f);
    }

    private void SetThrustToFalse()
    {
        thrustUp = false;
        speed = Random.Range(0.5f, 1f);
    }
}