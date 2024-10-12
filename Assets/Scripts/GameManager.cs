using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public AudioClip completeSound;

    private GroundPiece[] allGroundPieces;


    void Start()
    {
        SetupNewLevel();
        playerAudio = GetComponent<AudioSource>();
        explosionParticle.Stop();
        
    }

    private void SetupNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
    }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
        
        
    }

    public void CheckComplete()
    {
        bool isFinished = true;
        

        for(int i = 0; i < allGroundPieces.Length; i++)
        {
            if(allGroundPieces[i].isColoured == false)
            {
                isFinished = false;
                playerAudio.PlayOneShot(completeSound, 0.4f);
                explosionParticle.Play();
                break;
            }
        }

        if(isFinished)
        {
            // Next Level
            NextLevel();
        }
    }

    private void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }


    
}
