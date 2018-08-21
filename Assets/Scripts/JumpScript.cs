using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

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

            if ((Application.platform == RuntimePlatform.Android ||
                 Application.platform == RuntimePlatform.IPhonePlayer) && Input.touchCount > 0 && Input.GetMouseButtonDown(0) && canJump &&
                playJumpSound && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {

                jump = true;
                canJump = false;


                AudioManagerScript.instance.PlaySound("jump");

                Invoke("SetJumpToFalse", 0.1f);
            }

        if ((Application.platform == RuntimePlatform.OSXEditor) && Input.GetMouseButtonDown(0) && canJump && playJumpSound && !EventSystem.current.IsPointerOverGameObject())
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

    public bool CheckPressingPauseButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider !=  null)
        {
            if (hit.collider.gameObject.CompareTag("PauseButton")) return true;
        }



        return false;
    }

    private void OnDestroy()
    {
        PlayerCollisions.OnObstacleHit -= StopJumpSound;
    }
}