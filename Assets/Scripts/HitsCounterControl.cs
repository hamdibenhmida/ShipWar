using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitsCounterControl : MonoBehaviour
{
    Text hitCounterText;
    public static int hitsCounter = 0;
    public int maxHits = 40;
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
        hitCounterText.text = hitsCounter.ToString() ;
        if ( hitsCounter >= maxHits  )
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
