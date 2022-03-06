using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlayerAlive = true;
    
    public static GameManager gm;

    [SerializeField]
    private Transform playerStartPoint;

    public GameObject player;

    [SerializeField]
    CameraController cameraController;

    [SerializeField]
    private float dificulty;

    public float distance;
    private void Awake()
    {
        gm = this;
    }


    private void Update()
    {

        //Load scene
        if (!isPlayerAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (player!= null)
        {
            distance = Vector3.Distance(playerStartPoint.position, player.transform.position);
            UIManager.ui_m.setDistanceValue(distance);
        }

        cameraController.speed += Time.timeSinceLevelLoad / 10000 * dificulty;
        cameraController.speed = Mathf.Clamp(cameraController.speed, 1f, 50f);

    }
}
