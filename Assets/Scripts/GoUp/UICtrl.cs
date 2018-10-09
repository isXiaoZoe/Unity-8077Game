using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour {

    public GameObject end;
    public Text curInPlay;
    public Text curInEnd;
    public Text bestInPlay;
    public Text bestInEnd;

    public void showInPlay(int cur, int best)
    {
        curInPlay.text = cur.ToString();
        bestInPlay.text = best.ToString();
    }

    public void showInEnd(int cur, int best)
    {
        end.SetActive(true);
        curInEnd.text = cur.ToString();
        bestInEnd.text = best.ToString();
    }

    public void showCur(int cur)
    {
        curInPlay.text = cur.ToString();
    }

    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }
}
