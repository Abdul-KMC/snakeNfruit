using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ReplayBtn;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOver () {
        Time.timeScale = 0;
        ReplayBtn.SetActive(true);
    }

    public void OnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
