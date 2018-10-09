using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIChair : MonoBehaviour {

    public Text textLevel;
    public Text textChair;
    public Text textNum;

    public GameObject rule;
    public GameObject win;
    public GameObject lose;

    public void show(int level, int num)
    {
        textLevel.text = level.ToString();
        textChair.text = num.ToString();
        textNum.text = (num + 1).ToString();
    }

    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }
}
