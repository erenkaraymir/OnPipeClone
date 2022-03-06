using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
     private Vector3 axis = new Vector3(0,0,0);
    [SerializeField] private LayerMask layer;
    private PlayerControl playerControl;

    [SerializeField] private Color collect_color;
    [SerializeField] private Color nonCollect_color;
    [SerializeField]
    private AudioClip pickup_sound;

    private void Awake()
    {
        playerControl= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }
    void Update()
    {
        transform.Rotate(axis * Time.deltaTime);

        bool touchingPlayer = Physics.CheckSphere(transform.position, 0.2f, layer);

        if (playerControl.can_collect)
        {
            axis.y = 150;
            GetComponent<MeshRenderer>().material.color = collect_color;

            if (touchingPlayer)
            {
                playerControl.IncreaseHealt(2f);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(pickup_sound,0.2f);
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = nonCollect_color;

            axis.y = 45;
        }

        
    }
}
