
using UnityEngine;
using TMPro;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text textScore;
    public float scoreAmount;
    public float pointIncreasePerSecond;
    public int objetivos;
    private int lol;

    public Sound winSound;

    int playerObjetScore;
    public TMP_Text scoreObjText;

    public TMP_Text textScoreGameOver;
    public TMP_Text textTopScoreGameOver;

    public GameObject panelGameplay;
    public GameObject panelGameOver;

    private bool ganador = false;
    private bool juegoActivo = true;

    
    private void Awake()
    {
        Instance = this;
    }

 

    public void CheckHighScore()
    {
        if(scoreAmount < PlayerPrefs.GetInt("TopScore") && PlayerPrefs.GetInt("TopScore") != 0 && juegoActivo)
        {
            lol = (int)scoreAmount;
            PlayerPrefs.SetInt("TopScore", lol);
            AudioManager.Instance.PlaySound(winSound);
            juegoActivo = false;
        }
        else if (scoreAmount > PlayerPrefs.GetInt("TopScore") && PlayerPrefs.GetInt("TopScore") == 0 && juegoActivo)
        {
            lol = (int)scoreAmount;
            PlayerPrefs.SetInt("TopScore", lol);
            AudioManager.Instance.PlaySound(winSound);
            juegoActivo = false;
        }
        else
        {
            lol = (int)scoreAmount;
            AudioManager.Instance.PlaySound(winSound);
            juegoActivo = false;
        }
    }

    public void AddScore()
    {
        playerObjetScore++;
        scoreObjText.text = playerObjetScore.ToString()+"/5";
    }
    

    public void GameOver()
    {
        /*StartCoroutine(ResetSceneCoroutine());*/
        StartCoroutine(ShowGameOverPanelCoroutine());


    }

    public void Win()
    {
        if(playerObjetScore >= 5)
        {
            ganador = true;
            CheckHighScore();
            StartCoroutine(ShowGameOverPanelCoroutine());
            /*StartCoroutine(ResetSceneCoroutine());*/
        }
        
    }


    /*  private IEnumerator ResetSceneCoroutine()
      {
          yield return new WaitForSeconds(1.5f);
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }*/

    private IEnumerator ShowGameOverPanelCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        if(ganador == true)
        {
            textScoreGameOver.text = lol.ToString() + "s";
            ganador = false;
        }
        else
        {
            textScoreGameOver.text = "Sorry you lost";
        }
        
        textTopScoreGameOver.text = PlayerPrefs.GetInt("TopScore").ToString()+"s";
        panelGameplay.SetActive(false);
        panelGameOver.SetActive(true);
    }

    private void Start()
    {
        scoreAmount = 0f;
        pointIncreasePerSecond = 1f;
    }

    private void Update()
    {
        textScore.text = (int)scoreAmount + "s";
        scoreAmount += pointIncreasePerSecond = Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Player))
        {
            Win();
        }

    }
}








