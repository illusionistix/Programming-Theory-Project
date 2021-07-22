using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerPrefab;
    private PlayerController player;

    [SerializeField] private GameObject coinPrefab;
    private GameObject coin;

    [SerializeField] private Text scoreText;

    private Vector3 spawnPos;
    private Vector3 randomPos;

    //private int score;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0f, 1f, 0f);
        SpawnPlayer();
        //randomPos = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(10f, 20f));
        SpawnCoins();
        
    }

    private void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnPos, playerPrefab.transform.rotation);
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < 10; i++)
        {
            randomPos = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(10f, 20f));
            coin = Instantiate(coinPrefab, randomPos, coinPrefab.transform.rotation);
        }
    }

    private void QuitPlaying()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void UpdateScoreText()
    {
        scoreText.text = "$: " + MainManager.Instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitPlaying();
        }

        UpdateScoreText();
    }
}
