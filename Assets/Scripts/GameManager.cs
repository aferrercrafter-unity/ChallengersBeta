using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Scene info

    //Unity Prefabs
    public GameObject skeleton;

    //Message Panel
    public GameObject mask;
    public GameObject MessagePanel;

    //HUD    
    public Text timerLabel;

    //Panel labels
    public Text title;
    public Text subtitle;
    public Text totalTime;
    public Text totalLevel;

    //Private

    //Scene counters
    bool timerOn;
    float timer = 30;
    int level = 1;

    //States
    bool win_state = false;
    bool lose_state = true;

    //Enemy spawn points
    public Transform[] spawnPositions;  

    // Use this for initialization
    void Start () {        

        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerLabel.text = ((int)timer).ToString();

        if(timer <= 0 && !win_state)
        {
            Win();
        }
	}    

    public void Lost()
    {
        Time.timeScale = 0;
        level--;  
        title.text = "You Lose!";
        subtitle.text = "Good Day Sir!";
        SetUIScore(false);
        MessagePanel.SetActive(true);
        mask.SetActive(true);
    }

    public void Win()
    {
        win_state = true;
        Time.timeScale = 0;        
        title.text = "You Win!";
        subtitle.text = "Get ready for level " + level + " !";
        SetUIScore(true);
        MessagePanel.SetActive(true);
        mask.SetActive(true);
        level++;
    }

    public void NextLevel()
    {
        win_state = false;
        Time.timeScale = 1;
        MessagePanel.SetActive(false);
        mask.SetActive(false);
        timer = 30;
        Spawn();
    }    

    public void SetUIScore(bool win)
    {   
        if(win)     
            totalTime.text = "Total time: " + (((level - 1) * 30) + (30 - (int)timer)) + " sec";
        else
            totalTime.text = "Total time: " + (30 - (int)timer) + " sec";
        totalLevel.text = "Levels passed: " + level;
    }

    void Spawn()
    {
        /*
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        */
        if(level <= 4)
        {
            for (int i = 0; i < level; i++)
            {
                Instantiate(skeleton, spawnPositions[i].position, Quaternion.identity);
            }
        }        

    }
}
