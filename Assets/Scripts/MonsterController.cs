using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MonsterController : MonoBehaviour
{
    public Transform targetPosition;
    CharacterController cc;
    Seeker seeker;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        cc = GetComponent<CharacterController>();

    }
}
