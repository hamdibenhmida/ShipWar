using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitsCounterControl : MonoBehaviour
{
    Text hitCounterText;
    public Text timerText;

    public static int hitsCounter = 0;
    public int maxHits = 40;
    public float targetTime = 10.0f;
    public static bool gameOver = false;
    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        win.SetActive(false);
        lose.SetActive(false);
        hitsCounter = 0;
        hitCounterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        hitCounterText.text = hitsCounter.ToString() ;
        timerText.text = targetTime.ToString("0") + "s";
        

        if ( hitsCounter >= maxHits || targetTime <= 0.0f)
        {
            gameOver = true ;
        }
       

        if (gameOver )
        {
            if (hitsCounter >= maxHits)
                win.SetActive(true) ;
            else lose.SetActive(true) ;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
