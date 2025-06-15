using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadCityScene()
    {
        SceneManager.LoadSceneAsync("City");
    }

    public void LoadTownScene()
    {
        SceneManager.LoadSceneAsync("Town");
    }

    public void LoadVillageScene()
    {
        SceneManager.LoadSceneAsync("Village");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void LoadOfficeScene()
    {
        SceneManager.LoadSceneAsync("Office");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}