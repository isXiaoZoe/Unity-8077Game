using System.Collections;
using UnityEngine;

public class GameCtrller : MonoBehaviour {

    private int num = 8;
    private int level = 1;

    public Character prefMajor;
    public Character prefMinor;
    public GameObject prefChair;

    private Vector3 chairPos;
    private Vector3 MajorPos;
    private Vector3 MinorPos;

    private Quaternion rot;

    public UIChair ui;
    public AudioClip[] songs;

    private Character[] characs;
    private GameObject[] chairs;
    private AudioClip song;

    public AudioSource source;

    public bool rotate = false;
    private bool match = false;
    private bool press = false;

    private void Start()
    {
        print("Start");
        chairPos = prefChair.transform.position;
        MajorPos = prefMajor.transform.position;
        MinorPos = prefMinor.transform.position;

        rot = prefChair.transform.rotation;

        ui.show(level, num);
        init();
    }

    private void init()
    {
        print("Init");
        characs = new Character[num + 1];
        chairs = new GameObject[num];

        characs[0] = Instantiate(prefMajor);
        characs[0].gctrl = this;
        characs[0].gameObject.SetActive(false);

        for (int i =0; i < num; ++i)
        {
            characs[i + 1] = Instantiate(prefMinor);
            characs[i + 1].gctrl = this;
            characs[i + 1].gameObject.SetActive(false);
            chairs[i] = Instantiate(prefChair); 
            chairs[i].SetActive(false);
        }
    }

    private IEnumerator setChair(int num)
    {
        float angle = 360f / num;
        for(int i = 0; i < num; ++i)
        {
            chairs[i].transform.RotateAround(Vector3.zero, Vector3.forward, angle * i);
            chairs[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }

        StartCoroutine(setCharac(num));
    }

    private IEnumerator setCharac(int num)
    {
        float angle = 360f / (num + 1);

        characs[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        for(int i = 1; i <= num; ++i)
        {
            characs[i].transform.RotateAround(Vector3.zero, Vector3.forward, angle * i);
            characs[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        rotate = true;
        StartCoroutine(gameRun());
    }

    private IEnumerator play()
    {
        song = songs[Random.Range(0, 4)];
        source.clip = song;
        source.Play();
        while (source.isPlaying)
        {
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(setChair(num));
    }

    private IEnumerator gameRun()
    {
        while (!press)
        {
            if (!source.isPlaying)
            {
                if (!match)
                {
                    source.clip = songs[Random.Range(0, 4)];
                    source.Play();
                }
                else
                    break;
            }
            if (source.clip == song)
                match = true;
            yield return new WaitForSeconds(0.1f);
        }
        if (source.isPlaying)
            source.Stop();

        if(press && match)
            ui.win.SetActive(true);
        else
            ui.lose.SetActive(true);
        reset();
    }

    private void reset()
    {
        press = false;
        rotate = false;
        match = false;

        characs[0].transform.position = MajorPos;
        characs[0].transform.rotation = rot;
        characs[0].gameObject.SetActive(false);

        for (int i = 0; i < num; ++i)
        {
            chairs[i].transform.position = chairPos;
            chairs[i].transform.rotation = rot;
            chairs[i].SetActive(false);

            characs[i + 1].transform.position = MinorPos;
            characs[i + 1].transform.rotation = rot;
            characs[i + 1].gameObject.SetActive(false);
        }
    }

    private void next()
    {
        --num;
        ++level;
        if (num < 1) return;
        ui.show(level, num);
        StartCoroutine(play());
    }

    public void OnBtnStart()
    {
        ui.rule.SetActive(false);
        ui.show(level, num);
        StartCoroutine(play());
    }

    public void OnBtnPress()
    {
        if (!press && rotate)
        {
            press = true;
            rotate = false;
        }
    }

    public void OnBtnNext()
    {
        next();
        if (num != 0) ui.win.SetActive(false);
    }
}
