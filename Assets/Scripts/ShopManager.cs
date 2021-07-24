using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private Text[] itemTexts;
    [SerializeField] private Text[] inventoryTexts;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image energyBar;

    private GameObject item;
    private Vector3 spawnPos;

    private int index;
    private int price;
    private float energy;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(-3f, 0.5f, 0f);
        SpawnItem(Random.Range(0, 3));
    }

    //ABSTRACTION
    private void SpawnItem(int i)
    {
        item = Instantiate(itemPrefabs[i], spawnPos, itemPrefabs[i].transform.rotation);
        itemTexts[i].gameObject.SetActive(true);
        index = i;

    }

    //ABSTRACTION
    private void SelectNextItem()
    {
        itemTexts[index].gameObject.SetActive(false);
        index += 1;
        Destroy(item.gameObject);

        if (index < itemPrefabs.Length)
        {
            SpawnItem(index);
        }
        else if (index >= itemPrefabs.Length)
        {
            index = 0;
            SpawnItem(index);
        }

    }

    //ABSTRACTION
    private void SelectPreviousItem()
    {
        itemTexts[index].gameObject.SetActive(false);
        index -= 1;
        Destroy(item.gameObject);

        if (index >= 0)
        {
            SpawnItem(index);
        }
        else if (index < 0)
        {
            index = 2;
            SpawnItem(index);
        }

    }

    //ABSTRACTION
    private void SetPrice()
    {
        if (index == 0)
        {
            price = 15;
        }
        else if (index == 1)
        {
            price = 10;
        }
        else if (index == 2)
        {
            price = 35;
        }
    }

    //ABSTRACTION
    private void SetEnergyGain()
    {
        if (index == 0)
        {
            energy = MainManager.Instance.bananaEnergyGain;
        }
        else if (index == 1)
        {
            energy = MainManager.Instance.appleEnergyGain;
        }
        else if (index == 2)
        {
            energy = MainManager.Instance.crateEnergyGain;
        }
    }

    //ABSTRACTION
    private void AddItemToInventory()
    {
        if (index == 0)
        {
            MainManager.Instance.bananaCount += 1;
        }
        else if (index == 1)
        {
            MainManager.Instance.appleCount += 1;
        }
        else if (index == 2)
        {
            MainManager.Instance.crateCount += 1;
        }
    }

    //ABSTRACTION
    private void PayItem()
    {
        MainManager.Instance.score -= price;
    }

    //ABSTRACTION
    private void BuyItem()
    {
        if (MainManager.Instance.score > 0)
        {
            SetPrice();
            SetEnergyGain();
            PayItem();
            AddItemToInventory();
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

        if (energy < 100)
        {
            energyBar.transform.localScale = new Vector3(energy / 100, 1, 1);
        }
        else
        {
            energyBar.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //ABSTRACTION
    private void InventoryUpdateItemTexts()
    {
        inventoryTexts[0].text = MainManager.Instance.bananaCount.ToString();
        inventoryTexts[1].text = MainManager.Instance.appleCount.ToString();
        inventoryTexts[2].text = MainManager.Instance.crateCount.ToString();
    }

    //ABSTRACTION
    private void QuitShopping()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectNextItem();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectPreviousItem();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            QuitShopping();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            BuyItem();
        }

        UpdateScoreText();
        UpdateEnergyBar();
        InventoryUpdateItemTexts();
    }
}
