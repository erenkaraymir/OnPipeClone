using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField]
    private GameObject cylinder;
    private GameObject previous_cylinder;

    [Header("Game Component")]
    [SerializeField]
    private Color enemyColor;
    [SerializeField]
    private float minRadius;
    [SerializeField]
    private float maxRadius;

 
    private float FindRadius(float minR,float maxR)
    {
        
        float radius = Random.Range(minR, maxR);
        if (previous_cylinder != null)
        {
            while (Mathf.Abs(radius - previous_cylinder.transform.localScale.x) < 0.6f)
            {
                radius = Random.Range(minR, maxR);
            }
        }
        

        return radius;
    }

    public void spawnCylinder()
    {
        float radius = FindRadius(minRadius, maxRadius);
        float height = Random.Range(2f, 5f);
        cylinder.transform.localScale = new Vector3(radius, height, radius);

        if (previous_cylinder == null )
        {
            previous_cylinder = Instantiate(cylinder, Vector3.zero, Quaternion.identity);

        }
        else
        {
            float spawnPoint = previous_cylinder.transform.position.z + previous_cylinder.transform.localScale.y + cylinder.transform.localScale.y;
            previous_cylinder = Instantiate(cylinder, new Vector3(0f, 0f, spawnPoint), Quaternion.identity);

            //previous_cylinder.transform.localScale = new Vector3(radius, height, radius);

            if (Random.value < 0.1f)
            {
                previous_cylinder.GetComponent<Renderer>().material.color = enemyColor;
                previous_cylinder.tag = "Enemy";
            }
        }
        previous_cylinder.transform.Rotate(90, 0, 0);
    }
} 