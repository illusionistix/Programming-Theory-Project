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
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image energyBar;
    [SerializeField] private Enemy enemyPrefab;

    private Vector3 spawnPos;
    private Vector3 randomPos;
    private float energy;

    // Start is called before the first frame update
    void Start()
    {
        energy = 100f;

        spawnPos = new Vector3(0f, 0f, 0f);
        
        SpawnPlayer();
        SpawnCoins();
        SpawnEnemies(1);
        
    }

    //ABSTRACTION
    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPos, playerPrefab.transform.rotation);
    }

    //ABSTRACTION
    private void SpawnCoins()
    {
        for (int i = 0; i < 10; i++)
        {
            randomPos = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(10f, 20f));
            Instantiate(coinPrefab, randomPos, coinPrefab.transform.rotation);
        }
    }

    //ABSTRACTION
    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }
    }

    //ABSTRACTION
    private void QuitPlaying()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    //ABSTRACTION
    private void UpdateScoreText()
    {
        scoreText.text = "$: " + MainManager.Instance.score;
    }

    //ABSTRACTION
    private void UpdateEnergyBar()
    {
        energy = MainManager.Instance.energy;

        if (energy > 0)
        {
            energyBar.transform.localScale = new Vector3(energy / 100, 1, 0);
        }
        else
        {
            energyBar.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitPlaying();
        }

        UpdateScoreText();
        UpdateEnergyBar();
    }
}
