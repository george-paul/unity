using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    void Start()
    {
        offset=transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;   
    }
}
