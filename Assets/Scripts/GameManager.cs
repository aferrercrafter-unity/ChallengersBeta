using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Scene info
    public int wave_time;

    //Unity Prefabs
    public GameObject skeleton;
    public GameObject player;

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
    public Text goButton;

    //Private
    Vector3 player_start_pos;

    //Scene counters
    bool timerOn;
    float timer;
    int level = 1;

    //States
    bool win_state = false;
    bool lose_state = true;

    //Enemy spawn points
    public Transform[] spawnPositions;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        player_start_pos = player.transform.position;
        timer = wave_time;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {           
            Application.Quit();
        }


        timer -= Time.deltaTime;
        timerLabel.text = ((int)timer).ToString();

        if (timer <= 0 && !win_state)
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
        goButton.text = "Start";
        SetUIScore(false);
        MessagePanel.SetActive(true);
        mask.SetActive(true);
        level = 1;
    }

    public void Win()
    {
        win_state = true;
        Time.timeScale = 0;
        title.text = "You Win!";
        subtitle.text = "Get ready for level " + level + " !";
        goButton.text = "Go";
        SetUIScore(true);
        MessagePanel.SetActive(true);
        mask.SetActive(true);
        level++;
    }

    public void NextLevel()
    {
        player.transform.position = player_start_pos;        
        win_state = false;
        Time.timeScale = 1;
        MessagePanel.SetActive(false);
        mask.SetActive(false);
        timer = wave_time;
        Spawn();
    }

    public void SetUIScore(bool win)
    {
        if (win)
            totalTime.text = "Total time: " + (((level - 1) * wave_time) + (wave_time - (int)timer)) + " sec";
        else
            totalTime.text = "Total time: " + (wave_time - (int)timer + level * wave_time) + " sec";
        totalLevel.text = "Levels passed: " + level;
    }

    void Spawn()
    {
        
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        int dif = (int)System.Math.Ceiling( (double)level/4);
        int minions = level - (dif - 1) * 4;
                
        for (int i = 0; i < minions; i++)
        {
            //Quaternion rot = Quaternion.
            var enemy = Instantiate(skeleton, spawnPositions[i].position, Quaternion.identity);
            enemy.transform.localScale = new Vector3(dif, dif, dif);
        }
        

    }
}
