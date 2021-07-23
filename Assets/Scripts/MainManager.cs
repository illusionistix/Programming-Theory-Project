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
