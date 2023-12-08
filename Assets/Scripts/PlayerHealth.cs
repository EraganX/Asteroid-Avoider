using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;

    public void Crash()
    {
        gameOverHandler.GameEnd();
        gameObject.SetActive(false);
    }
}
