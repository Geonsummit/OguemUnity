using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    public GameObject poop;
    public Text scoreTxt;
    public Text bestScore;
    public GameObject panel;
    public bool stopTrigger = true;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        stopTrigger = false;
        
        StopCoroutine(CreatePoopRoutine());

        if(score >=PlayerPrefs.GetInt("BestScore", 0))
        PlayerPrefs.SetInt("BestScore", score);

        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        panel.SetActive(true);
    }
    public void GameStart()
    {
        StartCoroutine(CreatePoopRoutine());
        panel.SetActive(false);
    }
    public void Score()
    {
        if (stopTrigger)
        {
            score++;
            scoreTxt.text = "Score : " + score;
        }
        
       
    }

    IEnumerator CreatePoopRoutine()
    {
        while(stopTrigger)
        {
            CreatePoop();
            yield return new WaitForSeconds(1);
        }
    }

    public void CreatePoop()
    {
        

        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        Instantiate(poop, pos, Quaternion.identity);
        
    }

        
}
