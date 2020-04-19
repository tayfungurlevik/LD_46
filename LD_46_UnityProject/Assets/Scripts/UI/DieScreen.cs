using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieScreen : MonoBehaviour
{
    public GameObject DiePanel, FinishPanel;
    private void OnEnable()
    {
        Baby.OnBabyDied += Baby_OnBabyDied;
        GameFinish.OnGameFinishLinePassed += GameFinish_OnGameFinishLinePassed;
    }

    private void GameFinish_OnGameFinishLinePassed()
    {
        FinishPanel.SetActive(true);
    }

    private void OnDisable()
    {
        Baby.OnBabyDied -= Baby_OnBabyDied;
        GameFinish.OnGameFinishLinePassed -= GameFinish_OnGameFinishLinePassed;
    }
    private void Baby_OnBabyDied()
    {
        DiePanel.SetActive(true);
    }

    // Start is called before the first frame update
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
