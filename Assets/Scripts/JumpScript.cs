using DG.Tweening;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [HideInInspector]
    public bool canJump;

    private float initalJointDistance;
    private SpringJoint2D joint;

    private bool jump;

    [SerializeField] [Range(0, 2f)] private float jumpDistance = 0.2f;

    [SerializeField] [Range(0, 10)] private float jumpForce = 3f;

    private Rigidbody2D rb;

    private GameObject spawner;
    
    [HideInInspector]
    public bool playJumpSound = true;


    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<SpringJoint2D>();

        initalJointDistance = joint.distance;

        spawner = GameObject.FindGameObjectWithTag("spawner");

        PlayerCollisions.OnObstacleHit += StopJumpSound;

        rb.freezeRotation = true;

        canJump = true;
    }

    private void StopJumpSound(PlayerCollisions sender)
    {
        playJumpSound = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump && playJumpSound == true)
        {
       
            jump = true;
            canJump = false;
         
            
            AudioManagerScript.instance.PlaySound("jump");
            
            Invoke("SetJumpToFalse", 0.1f);
        }

        if (joint != null && Vector2.Distance(spawner.transform.position, transform.position) <=
            initalJointDistance + 0.35f) canJump = true;

        if (Input.GetMouseButtonUp(0))
        {
            ;
            jump = false;
        }

    }

    private void SetCanJumpTrue()
    {
        canJump = true;
    }

    private void SetJumpToFalse()
    {
        jump = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (jump)
        {    
            rb.AddForce(transform.up * jumpForce);

            if (joint != null)
                joint.distance = initalJointDistance + jumpDistance;
        }

        if (!jump)
        {
            rb.velocity = Vector2.zero;
            if (joint != null)
                joint.distance = initalJointDistance;
        }
    }

    private void OnDestroy()
    {
        PlayerCollisions.OnObstacleHit -= StopJumpSound;
    }
}