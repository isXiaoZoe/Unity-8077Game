using System;
using System.Collections;
using UnityEngine;

public class GoupCtrl : MonoBehaviour
{
    public Color[] colors;
    public UICtrl ui;

    private Pedal[] pedals;
    private Player player;

    private int best;
    private int score;

    public static Action AddScore { get; private set; }
    public static Action GameOver { get; private set; }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("goUp"))
        {
            PlayerPrefs.SetInt("goUp", 0);
        }

        AddScore = addScore;
        GameOver = gameOver;
        best = PlayerPrefs.GetInt("goUp");
    }

    private void Start()
    {
        pedals = GetComponentsInChildren<Pedal>();
        player = GetComponentInChildren<Player>();

        init();
    }

    private void init()
    {
        score = 0;
        ui.showInPlay(score, best);
        player.reset();
        foreach(Pedal p in pedals)
        {
            p.reset();
        }
        Time.timeScale = 1;
        player.falldown();
        StartCoroutine(setGameObject());
    }

    private IEnumerator setGameObject()
    {
        
        for(int i = 0; i < pedals.Length; ++i)
        {
            pedals[i].setPos(i % 4, 2.935f);
            yield return new WaitForSeconds(0.05f);
        }
        foreach(Pedal p in pedals)
        {
            p.move();
        }
    }

    private void addScore()
    {
        ui.showCur(++score);
    }

    private void gameOver()
    {
        Time.timeScale = 0;
        StopAllCoroutines();
        if (score > PlayerPrefs.GetInt("goUp"))
        {
            PlayerPrefs.SetInt("goUp", score);
            best = score;
        }
        ui.showInEnd(score, best);
    }

    public void OnBtnRetry()
    {
        GC.Collect();
        ui.end.SetActive(false);
        init();
    }
}


