using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{


    [SerializeField]
    private GameObject pointObject;

    private void Start()
    {
        if (!this.gameObject.CompareTag("Enemy"))
        {
            CreatePoint();
        }
    }

    private void CreatePoint()
    {
        float radius = transform.localScale.z / 2;
        float radius_cube = pointObject.transform.localScale.x / 2;

        float minRange = transform.position.z - transform.localScale.y;
        float maxRange = transform.position.z + transform.localScale.y;


        Instantiate(pointObject, new Vector3(transform.position.x, transform.position.y + radius + radius_cube,Random.Range(minRange,maxRange)), Quaternion.identity);

    }
}
