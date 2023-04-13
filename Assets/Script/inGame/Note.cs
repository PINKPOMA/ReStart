using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Note : MonoBehaviour
{
    NodeGenerator node;
    Vector3 desPos;

    private Rigidbody2D rigid;
    [SerializeField]float speed;

    void Start()
    {
        node = GameObject.Find("NodeGenerator").GetComponent<NodeGenerator>();
        speed = node.scrollSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.smoothDeltaTime);
    }

    public void OnBecameInvisible()
    {
        if (gameObject.transform.position.y <= -7.5f)
        {
            Destroy(gameObject);
        }
    }
}