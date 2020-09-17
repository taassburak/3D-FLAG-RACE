using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    GameObject level;
    GameObject main;
    public static int zorluk = 0;
    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("main");
        level = GameObject.Find("levels");
        for (int i = 0; i < level.transform.childCount; i++)
        {
            level.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button(int buton)
    {
        if (buton == 1)
        {
            for (int i = 0; i < level.transform.childCount; i++)
            {
                level.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 0; i < main.transform.childCount; i++)
            {
                main.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (buton == 2)
        {
            Application.Quit();
        }
        else if (buton == 3)
        {
            SceneManager.LoadScene(1);
            zorluk = 1;
        }
        else if (buton==4)
        {
            SceneManager.LoadScene(1);
            zorluk = 2;
        }
        else if (buton==5)
        {
            SceneManager.LoadScene(1);
            zorluk = 3;
        }
        else if (buton==6)
        {
            for (int i = 0; i < level.transform.childCount; i++)
            {
                level.transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < main.transform.childCount; i++)
            {
                main.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    
}
