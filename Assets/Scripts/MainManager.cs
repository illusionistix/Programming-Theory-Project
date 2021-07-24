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
                Debug.Log("Technically, You just died!");
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
