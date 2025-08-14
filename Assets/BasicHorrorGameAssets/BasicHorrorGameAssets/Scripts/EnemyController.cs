using UnityEngine;
using UnityEngine.AI;
/*
public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    public float idleTime = 2f;
    public float walkSpeed = 2f; // Walking speed.
    public float chaseSpeed = 4f; // Chasing speed.
    public float sightDistance = 10f;
    public AudioClip idleSound;
    public AudioClip walkingSound;
    public AudioClip chasingSound;

    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private Animator animator;
    private float idleTimer = 0f;
    private Transform player;
    private AudioSource audioSource;

    private enum EnemyState { Idle, Walk, Chase }
    private EnemyState currentState = EnemyState.Idle;

    private bool isChasingAnimation = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        SetDestinationToWaypoint();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                idleTimer += Time.deltaTime;
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsChasing", false); // Ensure IsChasing is set to false in the idle state.
                PlaySound(idleSound);

                if (idleTimer >= idleTime)
                {
                    NextWaypoint();
                }

                CheckForPlayerDetection();
                break;

            case EnemyState.Walk:
                idleTimer = 0f;
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsChasing", false); // Set IsChasing to false when walking.
                PlaySound(walkingSound);

                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    currentState = EnemyState.Idle;
                }

                CheckForPlayerDetection();
                break;

            case EnemyState.Chase:
                idleTimer = 0f;
                agent.speed = chaseSpeed; // Set the chase speed.
                agent.SetDestination(player.position);
                isChasingAnimation = true; // Set to true in chase state.
                animator.SetBool("IsChasing", true); // Set IsChasing to true in chase state.

                // Play chasing sound.
                PlaySound(chasingSound);

                // Check if the player is out of sight and go back to the walk state.
                if (Vector3.Distance(transform.position, player.position) > sightDistance)
                {
                    currentState = EnemyState.Walk;
                    agent.speed = walkSpeed; // Restore walking speed.
                }
                break;
        }
    }

    private void CheckForPlayerDetection()
    {
        RaycastHit hit;
        Vector3 playerDirection = player.position - transform.position;

        if (Physics.Raycast(transform.position, playerDirection.normalized, out hit, sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                currentState = EnemyState.Chase;
                Debug.Log("Player detected!");
            }
        }
    }

    private void PlaySound(AudioClip soundClip)
    {
        if (!audioSource.isPlaying || audioSource.clip != soundClip)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }

    private void NextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        SetDestinationToWaypoint();
    }

    private void SetDestinationToWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentState = EnemyState.Walk;
        agent.speed = walkSpeed; // Set the walking speed.
        animator.enabled = true;
    }

    // Draw a green raycast line at all times and switch to red when the player is detected.
    private void OnDrawGizmos()
    {
        Gizmos.color = currentState == EnemyState.Chase ? Color.red : Color.green;
        Gizmos.DrawLine(transform.position, player.position);
    }
}*/


/*public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    public float idleTime = 2f;
    public float walkSpeed = 2f; // Walking speed.
    public float chaseSpeed = 4f; // Chasing speed.
    public float sightDistance = 10f;
    public AudioClip idleSound;
    public AudioClip walkingSound;
    public AudioClip chasingSound;

    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private Animator animator;
    private float idleTimer = 0f;
    private Transform player;
    private AudioSource audioSource;

    private enum EnemyState { Idle, Walk, Chase }
    private EnemyState currentState = EnemyState.Idle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        SetDestinationToWaypoint();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                idleTimer += Time.deltaTime;
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsChasing", false);
                PlaySound(idleSound);

                // If NavMeshAgent is moving while in Idle, switch to Walk
                if (agent.velocity.magnitude > 0.1f)
                {
                    currentState = EnemyState.Walk;
                    idleTimer = 0f;
                }
                else if (idleTimer >= idleTime)
                {
                    NextWaypoint();
                }

                CheckForPlayerDetection();
                break;

            case EnemyState.Walk:
                idleTimer = 0f;
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsChasing", false);
                PlaySound(walkingSound);

                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    currentState = EnemyState.Idle;
                }

                CheckForPlayerDetection();
                break;

            case EnemyState.Chase:
                idleTimer = 0f;
                agent.speed = chaseSpeed;
                agent.SetDestination(player.position);
                animator.SetBool("IsChasing", true);
                animator.SetBool("IsWalking", false);
                PlaySound(chasingSound);

                if (Vector3.Distance(transform.position, player.position) > sightDistance)
                {
                    currentState = EnemyState.Walk;
                    agent.speed = walkSpeed;
                }
                break;
        }
    }

    private void CheckForPlayerDetection()
    {
        RaycastHit hit;
        Vector3 playerDirection = player.position - transform.position;

        if (Physics.Raycast(transform.position, playerDirection.normalized, out hit, sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                currentState = EnemyState.Chase;
                Debug.Log("Player detected!");
            }
        }
    }

    private void PlaySound(AudioClip soundClip)
    {
        if (!audioSource.isPlaying || audioSource.clip != soundClip)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }

    private void NextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        SetDestinationToWaypoint();
    }

    private void SetDestinationToWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentState = EnemyState.Walk;
        agent.speed = walkSpeed;
        animator.enabled = true;
    }

    private void OnDrawGizmos()
    {
        if (player == null) return;

        Gizmos.color = currentState == EnemyState.Chase ? Color.red : Color.green;
        Gizmos.DrawLine(transform.position, player.position);
    }
}*/

public class EnemyController : MonoBehaviour
{
    [Header("Patrol")]
    public Transform[] waypoints;
    public float waypointTolerance = 0.5f;
    public float waitAtWaypoint = 2f;
    public float walkSpeed = 2f;

    [Header("Chase")]
    public float chaseSpeed = 4f;
    public float sightRange = 10f;
    [Range(0f, 360f)] public float viewAngle = 110f;
    public float loseSightTime = 3f; // seconds to give up chasing after losing sight

    [Header("References")]
    public Animator animator; // optional, assign if you use animator params
    public string walkParam = "IsWalking";
    public string chaseParam = "IsChasing";

    private NavMeshAgent agent;
    private Transform player;
    private int currentWaypointIndex = 0;
    private float waitTimer = 0f;
    private bool waiting = false;

    private float lastSeenTime = -Mathf.Infinity;
    private enum State { Patrol, Chase }
    private State currentState = State.Patrol;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null) Debug.LogError("EnemyController needs a NavMeshAgent.");

        if (animator == null)
        {
            animator = GetComponent<Animator>(); // optional auto-assign
        }

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null) Debug.LogWarning("Player not found. Make sure the Player has tag 'Player'.");

        agent.autoBraking = false;
        agent.speed = walkSpeed;

        if (waypoints != null && waypoints.Length > 0)
        {
            SetDestinationToWaypoint();
        }
        else
        {
            agent.isStopped = true;
            Debug.LogWarning("No waypoints assigned - enemy will stay put.");
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                PatrolUpdate();
                if (CanSeePlayer())
                {
                    StartChase();
                }
                break;

            case State.Chase:
                ChaseUpdate();
                // if lost sight for > loseSightTime, return to patrol
                if (Time.time - lastSeenTime > loseSightTime)
                {
                    StopChaseAndReturnToPatrol();
                }
                break;
        }

        UpdateAnimatorFlags();
    }

    // Patrol behaviour: move to waypoint, wait, go to next.
    private void PatrolUpdate()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitAtWaypoint)
            {
                waiting = false;
                NextWaypoint();
            }
            return;
        }

        // If agent reached waypoint (within tolerance)
        if (!agent.pathPending && agent.remainingDistance <= waypointTolerance)
        {
            waiting = true;
            waitTimer = 0f;
            agent.isStopped = true;
            // you might want to play idle animation here
        }
    }

    private void NextWaypoint()
    {
        agent.isStopped = false;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        SetDestinationToWaypoint();
    }

    private void SetDestinationToWaypoint()
    {
        agent.speed = walkSpeed;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    // Chase behaviour: set destination to player's position every frame
    private void ChaseUpdate()
    {
        if (player == null) return;

        agent.isStopped = false;
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);

        // update lastSeenTime if the player is visible this frame
        if (CanSeePlayer())
        {
            lastSeenTime = Time.time;
        }
    }

    private void StartChase()
    {
        currentState = State.Chase;
        lastSeenTime = Time.time;
        // (optional) play chase sound or animation here
    }

    private void StopChaseAndReturnToPatrol()
    {
        currentState = State.Patrol;
        // Resume patrol to the nearest waypoint or current target
        agent.speed = walkSpeed;
        SetDestinationToWaypoint();
    }

    // Returns true if enemy can detect player (distance, FOV and no obstruction)
    private bool CanSeePlayer()
    {
        if (player == null) return false;

        Vector3 eyePos = transform.position + Vector3.up * 1.2f; // tweak eye height
        Vector3 dirToPlayer = (player.position + Vector3.up * 0.9f - eyePos);
        float dist = dirToPlayer.magnitude;
        if (dist > sightRange) return false;

        float angleToPlayer = Vector3.Angle(transform.forward, dirToPlayer.normalized);
        if (angleToPlayer > viewAngle * 0.5f) return false;

        // Raycast to check for obstruction
        RaycastHit hit;
        if (Physics.Raycast(eyePos, dirToPlayer.normalized, out hit, sightRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
            return false;
        }

        return false;
    }

    private void UpdateAnimatorFlags()
    {
        if (animator == null) return;

        if (currentState == State.Patrol)
        {
            bool isWalking = !waiting && agent.velocity.magnitude > 0.1f;
            animator.SetBool(walkParam, isWalking);
            animator.SetBool(chaseParam, false);
        }
        else if (currentState == State.Chase)
        {
            animator.SetBool(walkParam, false);
            animator.SetBool(chaseParam, true);
        }
    }

    // Debug visuals: sight cone and current state
    void OnDrawGizmosSelected()
    {
        Gizmos.color = (currentState == State.Chase) ? Color.red : Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        // draw FOV lines
        Vector3 forward = transform.forward;
        Quaternion leftRot = Quaternion.Euler(0, -viewAngle * 0.5f, 0);
        Quaternion rightRot = Quaternion.Euler(0, viewAngle * 0.5f, 0);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position + Vector3.up * 1.2f, leftRot * forward * sightRange);
        Gizmos.DrawRay(transform.position + Vector3.up * 1.2f, rightRot * forward * sightRange);
    }
}

