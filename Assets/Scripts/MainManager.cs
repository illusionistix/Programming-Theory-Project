using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    //ENCAPSULATION
    private int m_score = 0;
    public int score {

        get { return m_score; }

        set {
            
                if (value < 0)
                {
                    Debug.Log("Not enough cash!");
                }
                else
                {
                    m_score = value;
                }
              
            } 
    }

    //ENCAPSULATION
    private float m_energy = 100f;

    public float energy
    {
        get { return m_energy; }

        set
        {
            if (value < 0)
            {
                Debug.Log("Technically, the player character just died!");
            }
            else if (value > 100)
            {
                Debug.Log("Max energy reached!");
            }
            else
            {
                m_energy = value;
            }
        }
    }

    //ENCAPSULATION
    private int m_bananaCount = 0;
    public int bananaCount
    {

        get { return m_bananaCount; }

        set
        {

            if (value > 99)
            {
                Debug.Log("Max bananas!");
            }
            else if (value < 0)
            {
                Debug.Log("Just used the last banana!");
            }
            else
            {
                m_bananaCount = value;
            }

        }
    }

    //ENCAPSULATION
    private int m_appleCount = 0;
    public int appleCount
    {

        get { return m_appleCount; }

        set
        {

            if (value > 99)
            {
                Debug.Log("Max apples!");
            }
            else if (value < 0)
            {
                Debug.Log("Just used the last apple!");
            }
            else
            {
                m_appleCount = value;
            }

        }
    }

    //ENCAPSULATION
    private int m_crateCount = 0;
    public int crateCount
    {

        get { return m_crateCount; }

        set
        {

            if (value > 99)
            {
                Debug.Log("Max supply crates!");
            }
            else if (value < 0)
            {
                Debug.Log("Just used the last supply crate!");
            }
            else
            {
                m_crateCount = value;
            }

        }
    }

    //ENCAPSULATION
    public static MainManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
