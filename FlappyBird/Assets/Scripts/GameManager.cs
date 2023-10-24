using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;
    public GameObject flappyPlayer;
    public Text scoreText;
    public Text scoreRecord;
    public Text scoreRecordBest;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject name;
    public GameObject record;
    public GameObject recordScreen;
    public GameObject volumeScreenON;
    public GameObject volumeScreenOFF;
    public GameObject updateButton;
    public GameObject updateScreen;
    public GameObject updateClose;
    private bool audioOn = true;

    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;
    public AudioSource AudioSourceDeath;
    public AudioSource AudioSourceBackGround;

    public int score { get; private set; }
    public int highScore { get; private set; }

    private void Awake()
    {
        // PlayerPrefs.DeleteAll();
        Application.targetFrameRate = 120;
        SavingBestScore();
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        scoreRecordBest.text = highScore.ToString();
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        name.SetActive(true);
        gameOver.SetActive(false);
        recordScreen.SetActive(false);
        scoreRecord.enabled = false;
        scoreText.enabled = true;
        volumeScreenOFF.SetActive(false);
        updateButton.SetActive(true);
        updateScreen.SetActive(false);
        updateClose.SetActive(false);
        Pause();
    }

    public void Play()
    {
        SavingBestScore();
        score = 0;
        scoreText.text = score.ToString();
        scoreRecordBest.text = highScore.ToString();
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);

        flappyPlayer.SetActive(true);
        name.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);
        record.SetActive(false);
        recordScreen.SetActive(false);
        scoreText.enabled = true;
        updateButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        playButton.SetActive(true);
        gameOver.SetActive(true);
        record.SetActive(true);
        AudioSourceDeath.Play();
        SavingBestScore();
        Pause();
    }

    public void Pause()
    {
        SavingBestScore();
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void RecordScreenOnClick()
    {
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        scoreRecord.text = score.ToString();
        recordScreen.SetActive(true);
        gameOver.SetActive(false);
        record.SetActive(false);
        name.SetActive(true);
        flappyPlayer.SetActive(false);
        scoreRecord.enabled = true;
        scoreText.enabled = false;
        updateButton.SetActive(false);
        SavingBestScore();
    }

    public void SavingBestScore()
    {
        if (highScore < score)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            scoreRecordBest.text = highScore.ToString();
        }
    }

    public void OnClickVolume()
    {
        audioOn = !audioOn;
        if (audioOn == true)
        {
            AudioSourceBackGround.volume = 0.6f;
            volumeScreenOFF.SetActive(false);
        }
        else
        {
            AudioSourceBackGround.volume = 0f;
            volumeScreenOFF.SetActive(true);
        }
    }

    public void OnClickUpdates()
    {
        updateScreen.SetActive(true);
        updateClose.SetActive(true);
    }

    public void OnCloseUpdateScreen()
    {
        updateScreen.SetActive(false);
        updateClose.SetActive(false);
    }
}
