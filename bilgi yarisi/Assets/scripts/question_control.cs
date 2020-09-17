using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class question_control : MonoBehaviour
{
    public GameObject[] Answers;
    public GameObject[] flags;

    public static int seviye;

    public Text skorText ;
    int rnd1;
    int rnd2;

    int Prnd1;
    int Prnd2;
    int Prnd3;

    int fRnd;

    public static string correctAns;

    public static int score=0;

    public GameObject ins;
    public GameObject dest;

    public GameObject quesArea;
    void Start()
    {

        score = 0;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="inst")
        {
            flag();
            return;
        }
        

        if (other.gameObject.tag == correctAns)
        {
            score++;
            skorText.text = "SCORE : " + score;

            Debug.Log(score);
            Destroy(flags[fRnd].gameObject, 2);
            Destroy(flags[fRnd].gameObject, 2);



        }
        if (other.gameObject.tag != correctAns)
        {
            Debug.Log("gameover");
            SceneManager.LoadScene(0);
        }


    }

    public void flag()
    {
        seviye = menuControl.zorluk;
        if (seviye == 1)
        {
            if (score < flags.Length)
            {
                do
                {
                    fRnd = Random.Range(0, flags.Length);
                }
                while (flags[fRnd] == null);
            }

            Debug.Log("frnd" + fRnd);


            Instantiate(flags[fRnd], new Vector3(3, 55, transform.position.z + 200), Quaternion.Euler(0, 0, 180));//instantiate for flags
            correctAns = flags[fRnd].transform.GetChild(0).tag;
            do
            {

                rnd1 = Random.Range(0, flags.Length);

                rnd2 = Random.Range(0, flags.Length);

            }
            while ((rnd1 == rnd2) || (Answers[rnd1].tag == correctAns) || (Answers[rnd2].tag) == correctAns);//2diff random number for 2 wrong answers


            do
            {

                Prnd1 = Random.Range(-1, 2);

                Prnd2 = Random.Range(-1, 2);

                Prnd3 = Random.Range(-1, 2);
            }
            while ((Prnd1 == Prnd2) || (Prnd2 == Prnd3) || (Prnd3 == Prnd1));//3diff random number for position of answers

            Instantiate(quesArea, new Vector3(-6, 0, transform.position.z + 260), Quaternion.identity);



            Instantiate(flags[fRnd].transform.GetChild(0).gameObject, new Vector3(30 * Prnd1, 9,
                    transform.position.z + 200),
                    Quaternion.identity);//corretc answer

            Instantiate(Answers[rnd1], new Vector3(30 * Prnd2, 9,
                    transform.position.z + 200),
                    Quaternion.identity);//wrong answer

            Instantiate(Answers[rnd2], new Vector3(30 * Prnd3, 9,
                    transform.position.z + 200),
                    Quaternion.identity);//wrong answer






            Instantiate(ins.gameObject, new Vector3(0, 0, transform.position.z + 300), Quaternion.identity);



            flags.SetValue(null, fRnd);
        }

        else if (seviye == 2)
        {
            Debug.Log("seviye2");

        }
        else if (seviye == 3)
        {
            Debug.Log("seviye3");
        }


        
    }
    

    
}
 
    

