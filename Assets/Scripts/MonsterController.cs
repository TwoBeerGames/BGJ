using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MonsterController : MonoBehaviour
{
    public static MonsterController inst;
    [Header("References")]
    AIPath path;
    public Animator monsterAnimator;
    public List<PointOfInterest> pointsOfInterest = new List<PointOfInterest>();
    public Transform player;
    public Transform scanOrigin;
    public Transform currentTarget;
    [Header("Settings")]
    [Range(0f, 5f)]
    public float speedMultiplier = 1f;
    [Range(0, 20f)]
    public float forwardVisionRange = 1f;
    public LayerMask whatIsRaycastable;
    [Range(0, 180)]
    public float visionConeAngle = 45;
    public int scanRows = 3;
    public int samplesPerRow = 12;
    public float reevaluteTargetInterval = 4f;
    [Header("StateMachine")]
    public string currentState;
    public const string patrolingState = "1";
    public const string aggroState = "2";
    const string idleAnimation = "IdleSniffleAround";
    public bool playerInPerceptionRange = false;
    public float flashLightAggro = 3f;

    float initialSpeed = 0;
    public float initialSpeedMultiplier = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            StartCoroutine(performDeath());
        }
    }
    IEnumerator performDeath()
    {
        GlobalInput.masterInput.Disable();
        GlobalInput.leftDown = false;
        GlobalInput.rightDown = false;
        GlobalInput.forwardDown = false;
        GlobalInput.backwardDown = false;
        PlayerController.inst.scream();
        Fader.inst.goBlack(.1f);
        yield return new WaitForSecondsRealtime(2f);
        PlayerController.die.Invoke();
        currentTarget.position = pickNewPOI().position;
        MonsterDelay.inst.respawn();
        GlobalInput.masterInput.Enable();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            playerInPerceptionRange = false;
            currentState = aggroState;
            currentTarget.position = other.transform.position;
        }
    }

    public void Start()
    {
        initialSpeedMultiplier = speedMultiplier;

        path = GetComponent<AIPath>();
        currentTarget.position = transform.position;
        inst = this;

        Transform POIroot = GameObject.Find("POIroot").transform;

        foreach (Transform child in POIroot)
        {
            pointsOfInterest.Add(child.transform.GetComponent<PointOfInterest>());
        }

        currentState = patrolingState;
        StartCoroutine(evaluateNewTarget());


        initialSpeed = path.maxSpeed;
    }

    void playAnimation(string name)
    {
        monsterAnimator.Play(name);
    }
    public void FixedUpdate()
    {
        scan();
        manageAnimation();

    }

    private void OnEnable()
    {
        //speedMultiplier = initialSpeedMultiplier;
        Debug.Log(speedMultiplier);
        StartCoroutine(evaluateNewTarget());
        StartCoroutine(resetSpeed());
    }

    private void manageAnimation()
    {
        if (path.velocity.magnitude > .5f)
        {
            monsterAnimator.speed = speedMultiplier;
            path.maxSpeed = initialSpeed * speedMultiplier;
            playAnimation("walg");
        }
        else
        {
            path.maxSpeed = initialSpeed;
            monsterAnimator.speed = 1f;
            playAnimation(idleAnimation);
        }
    }

    void scan()
    {
        Vector3 currentRaycastVector = Vector3.zero;
        float sampleStep = 360 / samplesPerRow;
        float rowStep = visionConeAngle / 2 / scanRows;
        RaycastHit hit;

        for (int i = 0; i < scanRows; i++)
        {
            currentRaycastVector = Quaternion.AngleAxis(rowStep * i, transform.right) * scanOrigin.forward;

            for (int j = 0; j < samplesPerRow; j++)
            {
                Vector3 currentRaycastDirection = Quaternion.AngleAxis(j * sampleStep + (i % 2) * sampleStep / 2, transform.forward) * currentRaycastVector;
                Debug.DrawRay(scanOrigin.position, currentRaycastDirection * forwardVisionRange, Color.green, .1f);

                if (Physics.Raycast(transform.position, currentRaycastDirection, out hit, forwardVisionRange, whatIsRaycastable))
                {
                    if (hit.transform.gameObject.layer == 7 || hit.transform.gameObject.layer == 13)
                    {
                        currentState = aggroState;
                        currentTarget.position = player.position;
                        return;
                    }
                }
            }
        }

        currentState = patrolingState;
    }

    Transform pickNewPOI()
    {
        List<PointOfInterest> currentActiveList = new List<PointOfInterest>();

        List<PointOfInterest> POIsnapshot = pointsOfInterest.GetRange(0, pointsOfInterest.Count);

        int size = 0;
        int randomIndex = 0;

        foreach (PointOfInterest poi in POIsnapshot)
        {
            if (poi.isInRange)
            {
                currentActiveList.Add(poi);
                size++;
            }

        }

        if (currentActiveList.Count > 1)
        {

            randomIndex = Random.Range(0, size);
            if (currentActiveList[randomIndex].transform != currentTarget)
            {
                return currentActiveList[randomIndex].transform;
            }
            else
            {
                return pickNewPOI();
            }

        }
        else
        {
            randomIndex = Random.Range(0, pointsOfInterest.Count);
            return pointsOfInterest[randomIndex].transform;

        }
    }

    public void aggroPlayer()
    {
        currentState = aggroState;
        currentTarget.position = player.position;
    }

    public void buff(bool state)
    {
        if (state)
        {
            speedMultiplier = initialSpeedMultiplier * flashLightAggro;
        }
        else
        {
            speedMultiplier = initialSpeedMultiplier;
        }
    }

    IEnumerator resetSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            speedMultiplier = initialSpeedMultiplier;
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator evaluateNewTarget()
    {
        float timeElapsed = 0;

        while (true)
        {
            if (timeElapsed <= reevaluteTargetInterval)
            {
                timeElapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                continue;
            }

            timeElapsed = 0;

            if (currentState == patrolingState)
            {
                Transform newTarget = pickNewPOI();

                if (newTarget != null)
                    currentTarget.position = newTarget.position;

                currentState = patrolingState;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(scanOrigin.position, scanOrigin.position + scanOrigin.forward * forwardVisionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(currentTarget.position, 1f);
    }

}
