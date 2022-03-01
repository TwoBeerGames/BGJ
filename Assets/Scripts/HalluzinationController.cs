using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HalluzinationController : MonoBehaviour
{
    public AudioSource audioSource;
    public static MonsterController inst;
    public Animator halluzinationAnimator;
    public GameObject halluzinationAgent;
    public float speedIncrease;
    public AIPath path;
    public List<PointOfInterest> pointsOfInterest = new List<PointOfInterest>();
    public Transform player;
    public float halluzinationInterval = 1f;
    float initialAnimatorSpeed = 0f;
    float initialSpeed = 0;
    public float maxAnimatorSpeed = 2;



    public void Start()
    {
        initialAnimatorSpeed = halluzinationAnimator.speed;

        Transform POIroot = GameObject.Find("POIroot").transform;

        foreach (Transform child in POIroot)
        {
            pointsOfInterest.Add(child.transform.GetComponent<PointOfInterest>());
        }

        initialSpeed = path.maxSpeed;

        StartCoroutine(delay());
    }

  

    public void Update()
    {
        halluzinationAnimator.speed += Time.deltaTime * speedIncrease;
        path.maxSpeed += Time.deltaTime * speedIncrease;

        halluzinationAnimator.speed = Mathf.Clamp(halluzinationAnimator.speed, 0, maxAnimatorSpeed);
    }

    void OnDisable()
    {
        if (halluzinationAnimator) {
            halluzinationAnimator.speed = initialAnimatorSpeed;
        }
        path.maxSpeed = initialSpeed;

    }
    public void FixedUpdate()
    {
        if (Vector3.Distance(halluzinationAgent.transform.position, player.position) < 1.5f && halluzinationAgent.activeInHierarchy)
        {
            audioSource.Play();
            halluzinationAgent.SetActive(false);
            StartCoroutine(startHalluzniations());
        }
    }


    Transform pickNewPOI()
    {
        List<PointOfInterest> currentActiveList = new List<PointOfInterest>();

        List<PointOfInterest> POIsnapshot = pointsOfInterest.GetRange(0, pointsOfInterest.Count);

        int size = 0;
        foreach (PointOfInterest poi in POIsnapshot)
        {
            if (poi.isInRange)
            {
                currentActiveList.Add(poi);
                size++;
            }

        }

        if (currentActiveList.Count > 0)
        {
            int randomIndex = Random.Range(0, size);

            return currentActiveList[randomIndex].transform;
        }

        return null;
    }

    IEnumerator startHalluzniations()
    {
        yield return new WaitForSecondsRealtime(Random.Range(halluzinationInterval, 2 * halluzinationInterval));

        Transform newTarget = pickNewPOI();

        if (newTarget != null)
        {
            halluzinationAgent.transform.position = newTarget.position;
            halluzinationAgent.SetActive(true);
        }
    }

    IEnumerator delay()
    {
        halluzinationAgent.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(halluzinationInterval);
        halluzinationAgent.gameObject.SetActive(true);
    }
}

