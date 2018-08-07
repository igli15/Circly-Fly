using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] [Range(5, 20)] private float fallingSpeed = 10;

    private JumpScript jumpScript;

    private Rigidbody2D rb;
    private RotateScript rotateScript;

    private Animator animator;

    private bool shouldAddForce;

    private GameObject spawner;

    private SpringJoint2D spring;

    [SerializeField] [Range(0, 1)] 
    private float torqueForce = 0.6f;

    private void Start()
    {
        jumpScript = GetComponent<JumpScript>();
        rb = GetComponent<Rigidbody2D>();
        rotateScript = GetComponent<RotateScript>();
        spring = GetComponent<SpringJoint2D>();
        
        animator = GetComponent<Animator>();
        
        spawner = GameObject.FindGameObjectWithTag("spawner");
        PlayerCollisions.OnObstacleHit += OnDeath;
    }

    private void FixedUpdate()
    {
        if (shouldAddForce) rb.AddForce((spawner.transform.position - transform.position).normalized * fallingSpeed);
    }


    private void OnDeath(PlayerCollisions sender)
    {
        animator.SetBool("IsDead",true);
        
        if (spring != null)
        {
            spring.breakForce = 0;
            spring.autoConfigureDistance = true;
        }
        
        shouldAddForce = true;
        rb.freezeRotation = false;
         rb.AddTorque(torqueForce, ForceMode2D.Impulse);

        jumpScript.canJump = false;
        if (rotateScript != null) rotateScript.enabled = false;


        Invoke("RestartScene", 2);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        PlayerCollisions.OnObstacleHit -= OnDeath;
    }
}