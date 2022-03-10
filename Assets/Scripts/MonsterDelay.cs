using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDelay : MonoBehaviour
{
    public GameObject monster;
    public Vector3 startPosition = Vector3.zero;
    public static MonsterDelay inst;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = monster.transform.position;
        inst = this;
    }


    public void respawn()
    {
        StartCoroutine(__respawn());
    }

    IEnumerator __respawn()
    {
        monster.transform.position = startPosition;
        monster.SetActive(false);
        yield return new WaitForSeconds(10);
        monster.SetActive(true);


    }
}
