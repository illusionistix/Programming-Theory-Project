using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private Text[] itemTexts;
    [SerializeField] private Text scoreText;
    private GameObject item;
    private Vector3 spawnPos;
    private int index;
    private int price;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(-3f, 0.5f, 0f);
        SpawnItem(Random.Range(0, 3));
    }

    private void SpawnItem(int i)
    {
        item = Instantiate(itemPrefabs[i], spawnPos, itemPrefabs[i].transform.rotation);
        itemTexts[i].gameObject.SetActive(true);
        index = i;

    }

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

    private void BuyItem()
    {
        SetPrice();
        MainManager.Instance.score -= price;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "$: " + MainManager.Instance.score;
    }

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
    }
}
