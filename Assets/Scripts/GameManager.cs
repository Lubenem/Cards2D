using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image _background;

    public static GameManager instance;
    public bool globalInputBlock;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateBackgroundColor();
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void SetBackgroundColor(Color color)
    {
        PlayerPrefs.SetFloat("color.r", color.r);
        PlayerPrefs.SetFloat("color.g", color.g);
        PlayerPrefs.SetFloat("color.b", color.b);
        PlayerPrefs.SetFloat("color.a", color.a);
        UpdateBackgroundColor();
    }

    private void UpdateBackgroundColor()
    {
        float ColorR = PlayerPrefs.GetFloat("color.r");
        float ColorG = PlayerPrefs.GetFloat("color.g");
        float ColorB = PlayerPrefs.GetFloat("color.b");
        float ColorA = PlayerPrefs.GetFloat("color.a");
        Color color = new Color(ColorR, ColorG, ColorB, ColorA);
        _background.color = color;
    }
}