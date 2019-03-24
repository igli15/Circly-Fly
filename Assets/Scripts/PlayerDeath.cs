using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] [Range(5, 20)] private float fallingSpeed = 10;

    [SerializeField] private PopUp revivePopup;

    private JumpScript jumpScript;

    private Rigidbody2D rb;
    private RotateScript rotateScript;

    private Animator animator;

    private bool shouldAddForce;

    private GameObject spawner;

    private SpringJoint2D spring;

    private Collider collider;

    [SerializeField] [Range(0, 1)] 
    private float torqueForce = 0.6f;

    private float reviveCount = 0;

    private Vector3 initialPos;

    private void Start()
    {
        jumpScript = GetComponent<JumpScript>();
        rb = GetComponent<Rigidbody2D>();
        rotateScript = GetComponent<RotateScript>();
        spring = GetComponent<SpringJoint2D>();
        
        animator = GetComponent<Animator>();
        
        spawner = GameObject.FindGameObjectWithTag("spawner");
        PlayerCollisions.OnObstacleHit += OnDeath;

        initialPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (shouldAddForce) rb.AddForce((spawner.transform.position - transform.position).normalized * fallingSpeed);
    }


    private void OnDeath(PlayerCollisions sender)
    {
        animator.SetBool("IsDead",true);
        animator.SetBool("Revive",false);
        
        if (spring != null)
        {
            spring.enabled = false;
        }
        
        shouldAddForce = true;
        rb.freezeRotation = false;
        rb.AddTorque(torqueForce, ForceMode2D.Impulse);
        

        jumpScript.canJump = false;
        if (rotateScript != null) rotateScript.enabled = false;

        if (reviveCount >= 1)
        {
            Invoke("RestartScene",2);
        }
        else
        {
            revivePopup.Show();
            reviveCount += 1;
        }
    }
    
    public void Revive()
    {
        animator.SetBool("IsDead",false);
        animator.SetBool("Revive",true);

        GetComponent<PlayerCollisions>().isDead = false;
        GetComponent<RotateScript>().SetRotationSpeed(40);

        transform.position = initialPos;
        transform.rotation = Quaternion.identity;
        
        if (spring != null)
        {
            spring.enabled = true;
        }

        shouldAddForce = false;
        rb.freezeRotation = true;

        jumpScript.canJump = true;
        jumpScript.playJumpSound = true;
        if (rotateScript != null) rotateScript.enabled = true;
    }
    

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        PlayerCollisions.OnObstacleHit -= OnDeath;
    }
}