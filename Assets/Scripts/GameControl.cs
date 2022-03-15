using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip dieSFX;

    int playerScore = 0;

    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameControl>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = playerScore.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            AudioSource.PlayClipAtPoint(dieSFX, Camera.main.transform.position);
            Invoke("TakeLife", 1.42f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(dieSFX, Camera.main.transform.position);
            Invoke("ResetGameSession", 1.42f);
        }
    }

    public void IncreaseScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<ScenePersist>().ResetSceneSession();
        Destroy(gameObject);
    }

    void TakeLife()
    {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        livesText.text = playerLives.ToString();
    }

}
