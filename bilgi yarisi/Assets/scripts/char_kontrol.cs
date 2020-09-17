using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class char_kontrol : MonoBehaviour
{
    
    
    public float hiz;
    Rigidbody physics;
    GameObject kamera;
    Vector3 cameraOffset;
    float minx = -25;
    float maxx = 25;
    float miny = -8;
    float maxy = 14;
    int donusAcisi =0;
    float donusZamani = 0;  
    public Text end;
    //public Text score;
    public static string secim;

    public static int skor=0;

    GameObject ends;
    public static int zorluk1;
    
    // Start is called before the first frame update
    void Start()
    {
        zorluk1 = question_control.seviye;
        ends = GameObject.Find("ends");
        for (int i = 0; i < ends.transform.childCount; i++)
        {
            ends.transform.GetChild(i).gameObject.SetActive(false);
        }
        kamera = Camera.main.gameObject;
        cameraOffset = kamera.transform.position - transform.position;
        physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        secim = question_control.correctAns;
        skor = question_control.score;
        //score.text = "SCORE : " + skor;
        charMove();
        cameraControl();

        if (skor == 12)
        {
            for (int i = 0; i < ends.transform.childCount; i++)
            {
                ends.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

    }

    void cameraControl()
    {
        Vector3 newPos = transform.position + cameraOffset;
        newPos.Normalize();
        kamera.transform.position = new Vector3(kamera.transform.position.x, kamera.transform.position.y, transform.position.z-25);
    }

    void charMove()
    {
        
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
        
        
            Vector3 vec = new Vector3(horizontal, vertical, 3);
            vec.Normalize();
            physics.velocity = vec * hiz;
            transform.position = new Vector3(Mathf.Clamp(physics.position.x, minx, maxx),
            Mathf.Clamp(physics.position.y, miny, maxy), physics.position.z);
        

        if(horizontal > 0)
        {
            
            donusZamani += Time.deltaTime;
            if (donusZamani>0.02f)
            {
                
                donusAcisi--;
                transform.rotation = Quaternion.Euler(0, 0, donusAcisi);
                
                if (donusAcisi <= -21)
                {
                    donusAcisi = -21;
                }
                donusZamani = 0;
            }
            
            
            
            
        }
        else if(horizontal < 0)
        {
            
            donusZamani += Time.deltaTime;
            if (donusZamani > 0.02f)
            {
                
                donusAcisi++;
                transform.rotation = Quaternion.Euler(0, 0, donusAcisi);
                donusZamani = 0;
                if (donusAcisi >= 21)
                {
                    donusAcisi = 21;
                }
            }
            
            
            
        }
         else if(horizontal==0)
        {
            
           

            if (transform.rotation.z >0)
            {
                donusZamani += Time.deltaTime;
                if (donusZamani > 0.02f)
                {
                    
                    donusAcisi--;
                    transform.rotation = Quaternion.Euler(0, 0, donusAcisi);
                    
                    if (donusAcisi <= 0)
                    {
                        donusAcisi = 0;
                    }
                    donusZamani = 0;
                }
            }
            if (transform.rotation.z < 0)
            {
                donusZamani += Time.deltaTime;
                if (donusZamani > 0.02f)
                {
                    
                    donusAcisi++;
                    transform.rotation = Quaternion.Euler(0, 0, donusAcisi);
                    
                    if (donusAcisi >= 0)
                    {
                        donusAcisi = 0;
                    }
                    donusZamani = 0;
                }
            }


        }
  
    }
    public void endButton(int secim)
    {
        if (secim == 0)
        {
            zorluk1 = question_control.seviye;
            for (int i = 0; i < ends.transform.childCount; i++)
            {
                ends.transform.GetChild(i).gameObject.SetActive(false);
            }
            SceneManager.LoadScene(1);
            
        }
        else if (secim == 1)
        {
            SceneManager.LoadScene(0);
        }
    }

}
