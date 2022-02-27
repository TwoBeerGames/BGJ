using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDelay : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        monster.SetActive(false);
        StartCoroutine(delay());
    }

    IEnumerator delay(){
        yield return new WaitForSeconds(30);
         monster.SetActive(true);
    }
}
