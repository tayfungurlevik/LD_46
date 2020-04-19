using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void OnEnable()
    {
        Baby.OnBabyDied += Baby_OnBabyDied;
    }
    private void OnDisable()
    {
        Baby.OnBabyDied -= Baby_OnBabyDied;
    }
    private void Baby_OnBabyDied()
    {
        
    }
}
