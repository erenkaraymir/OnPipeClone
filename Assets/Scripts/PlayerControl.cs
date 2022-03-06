using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region ConstValues
    private const float size_scale = 0.23f;
    private const float offset = 0.05f;
    private const float checkRadius = 0.18f;

    public float healt = 10.0f;
    #endregion

    #region SerializeField
    [SerializeField]
    private Vector3 default_size;

    [SerializeField]
    private LayerMask layerMask;
    #endregion
    [SerializeField]
    private AudioClip bing,deathSound;

    

    public bool can_collect;

    private void Update()
    {
        HealtCounter();

       Transform cyl = Physics.OverlapSphere(transform.position, checkRadius, layerMask)[0].transform;
        
        Vector3 scaleObj = cyl.localScale * size_scale;

        if (healt <= 0)
        {
            Death();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(bing,0.2f);
        }


        if (Input.GetMouseButton(0))
        {
          

            #region DeathByScale

            if (scaleObj.x > transform.localScale.x)
            {
                Death();
                print("Game Over");
            }
            #endregion

            #region DeathByEnemy
            if (cyl.gameObject.CompareTag("Enemy"))
            {
                if(scaleObj.x + offset > transform.localScale.x)
                {
                    Death();
                    print("Dead by Enemy");
                }
            }
            #endregion

           

            Vector3 targetScale = new Vector3(scaleObj.x, default_size.y, scaleObj.x);
            transform.localScale = Vector3.Slerp(transform.localScale, targetScale, 0.125f);
        }
        else
        {
            transform.localScale = Vector3.Slerp(transform.localScale, default_size, 0.125f);
        }

        if (scaleObj.x + offset > transform.localScale.x)
        {
            can_collect = true;
        }
        else
        {
            can_collect = false;
        }
    }

    #region DeathMethod
    private void Death()
    {
        if(Camera.main != null)
        {
            Camera.main.GetComponent<CameraController>().enabled = false;
        }

       UIManager.ui_m.activePanel();

        Camera.main.GetComponent<AudioSource>().PlayOneShot(deathSound,0.2f );

        if(GameManager.gm.distance > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", GameManager.gm.distance);
        }

        UIManager.ui_m.setHighScore();

        GameManager.gm.isPlayerAlive = false;

        Destroy(gameObject);
    }

    private void HealtCounter()
    {
        healt = Mathf.Clamp(healt, -1f, 10f);
        if(healt >=0)
        {
            healt -= Time.deltaTime;
            UIManager.ui_m.setPlayerHealth(healt);
        }
        else
        {
            print("gameover");
        }
        
    }

    public void IncreaseHealt(float value)
    {
        healt += value;
    }
    #endregion
     
}
