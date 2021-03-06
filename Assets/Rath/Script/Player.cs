using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    public float gravity;
    public Vector2 velocity;
    public float maxXVelocity = 100;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float distance = 0;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float maxMaxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 1;

    public bool isDead = false;

    public LayerMask groundLayerMask;
    public LayerMask obstacleLayerMask;

    Animator playerAnim;
    public bool isJumping;
    public bool isFalling;
    public bool isOnGround;
    public bool isDeadAnim;


    public bool IsMusicPlaying = false;




    void Awake()
    {
        playerAnim = gameObject.GetComponentInChildren<Animator>();
    }


    private void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/CatOne");

        if (IsMusicPlaying == false)
        {
            MusicPlayer();
        }
    }

    void Update()
    {
  
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Character/Player Jump", GetComponent<Transform>().position);
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;
            }
            
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                if (Input.touchCount >= 1)
                {
                    if (Input.touches[0].phase == TouchPhase.Began)
                    {
                        Debug.Log("Touch Pressed");
                        isGrounded = false;
                        velocity.y = jumpVelocity;
                        isHoldingJump = true;
                        holdJumpTimer = 0;
                    }

                    if (Input.touches[0].phase == TouchPhase.Ended)
                    {
                        Debug.Log("Touch Lifted/Released");
                        isHoldingJump = false;
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }

        
        
      

   

    }

    public void MusicPlayer()
    {
        IsMusicPlaying = true;
        instance.start();


    }



    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector2 pos = transform.position;

        if (pos.y < -20)
        {
            isDead = true;
            playerAnim.SetBool("isOnGround", false);
            playerAnim.SetBool("isFalling", false);
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isDeadAnim", true);
        }

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }


            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, groundLayerMask);
            if (hit2D.collider != null)
            {
                Ground ground = hit2D.collider.GetComponent<Ground>();
                if (ground != null)
                {
                    if (pos.y >= ground.groundHeight)
                    {
                        groundHeight = ground.groundHeight;
                        pos.y = groundHeight;
                        velocity.y = 0;
                        isGrounded = true;
                    }
                }
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);


            Vector2 wallOrigin = new Vector2(pos.x, pos.y);
            Vector2 wallDir = Vector2.right;
            RaycastHit2D wallHit = Physics2D.Raycast(wallOrigin, wallDir, velocity.x * Time.fixedDeltaTime, groundLayerMask);
            if (wallHit.collider != null)
            {
                Ground ground = wallHit.collider.GetComponent<Ground>();
                if (ground != null)
                {
                    if (pos.y < ground.groundHeight)
                    {
                        velocity.x = 0;
                        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        instance.release();
                    }
                }
            }
            if (velocity.y > 0)
            {
                playerAnim.SetBool("isOnGround", false);
                playerAnim.SetBool("isFalling", false);
                playerAnim.SetBool("isJumping", true);
            }

            if (velocity.y <= 0)
            {
                playerAnim.SetBool("isOnGround", false);
                playerAnim.SetBool("isJumping", false);
                playerAnim.SetBool("isFalling", true);
            }
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isFalling", false);
            playerAnim.SetBool("isOnGround", true);

            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            maxHoldJumpTime = maxMaxHoldJumpTime * velocityRatio;

            velocity.x += acceleration * Time.fixedDeltaTime;
            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }


            Vector2 rayOrigin = new Vector2(pos.x - 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if (hit2D.collider == null)
            {
                isGrounded = false;
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.yellow);

        }

        Vector2 obstOrigin = new Vector2(pos.x, pos.y);
        RaycastHit2D obstHitX = Physics2D.Raycast(obstOrigin, Vector2.right, velocity.x * Time.fixedDeltaTime, obstacleLayerMask);
        if (obstHitX.collider != null)
        {
            Obstacle obstacle = obstHitX.collider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                HitObstacle(obstacle);
            }
        }

        RaycastHit2D obstHitY = Physics2D.Raycast(obstOrigin, Vector2.up, velocity.y * Time.fixedDeltaTime, obstacleLayerMask);
        if (obstHitY.collider != null)
        {
            Obstacle obstacle = obstHitY.collider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                HitObstacle(obstacle);
            }
        }


        transform.position = pos;
    }


    void HitObstacle(Obstacle obstacle)
    {
        Destroy(obstacle.gameObject);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Character/Player_Hit", GetComponent<Transform>().position);
        velocity.x *= 0.7f;
    }
}
