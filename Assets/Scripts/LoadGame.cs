using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public GameObject home;
    public GameObject menu;
    
    public void OnStart()
    {
        home.SetActive(false);
        menu.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnBack()
    {
        menu.SetActive(false);
        home.SetActive(true);
    }

    public void OnGoUp()
    {
        SceneManager.LoadScene(1);
    }

    public void OnChair()
    {
        SceneManager.LoadScene(2);
    }

    public void OnBiu()
    {
        SceneManager.LoadScene(3);
    }
}
