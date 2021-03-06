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
    [SerializeField] private Text[] itemTexts;
    [SerializeField] private Image energyBar;
    [SerializeField] private Canvas inventory;
    [SerializeField] private Enemy enemyPrefab;

    private Vector3 spawnPos;
    private Vector3 randomPos;
    private float energy;
    private bool isInventoryActive;
    private static int spawnCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        isInventoryActive = false;
        inventory.gameObject.SetActive(false);

        energy = 100f;
        spawnPos = new Vector3(0f, 0f, 0f);
        
        SpawnPlayer();
        SpawnCoins();
        SpawnEnemies(spawnCount);
        
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
            randomPos = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(5f, 20f));
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }

        if (spawnCount < 5)
        {
            spawnCount += 1;
        }
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

    //ABSTRACTION
    private void ToggleInventory()
    {
        if (!isInventoryActive)
        {
            isInventoryActive = true;
            inventory.gameObject.SetActive(true);
        }
        else
        {
            isInventoryActive = false;
            inventory.gameObject.SetActive(false);
        }
    }

    //ABSTRACTION
    private void InventoryUpdateItemTexts()
    {
        itemTexts[0].text = MainManager.Instance.bananaCount.ToString();
        itemTexts[1].text = MainManager.Instance.appleCount.ToString();
        itemTexts[2].text = MainManager.Instance.crateCount.ToString();
    }

    //ABSTRACTION
    private void UseBananaItem()
    {
        if (MainManager.Instance.bananaCount > 0 && MainManager.Instance.energy < 100)
        {
            MainManager.Instance.energy += MainManager.Instance.bananaEnergyGain;
            MainManager.Instance.bananaCount -= 1;
        }        
    }

    //ABSTRACTION
    private void UseAppleItem()
    {
        if (MainManager.Instance.appleCount > 0 && MainManager.Instance.energy < 100)
        {
            MainManager.Instance.energy += MainManager.Instance.appleEnergyGain;
            MainManager.Instance.appleCount -= 1;
        }        
    }

    //ABSTRACTION
    private void UseCrateItem()
    {
        if (MainManager.Instance.crateCount > 0 && MainManager.Instance.energy < 100)
        {
            MainManager.Instance.energy += MainManager.Instance.crateEnergyGain;
            MainManager.Instance.crateCount -= 1;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseBananaItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseAppleItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseCrateItem();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitPlaying();
        }

        UpdateScoreText();
        UpdateEnergyBar();
        InventoryUpdateItemTexts();
    }
}
