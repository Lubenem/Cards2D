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
        PlayerPrefs.SetString("BackGround Color", $"{color.r},{color.g},{color.b},{color.a}");
        UpdateBackgroundColor();
    }

    private void UpdateBackgroundColor()
    {
        string colorString = PlayerPrefs.GetString("BackGround Color");
        if (colorString == String.Empty)
            return;
        string[] colorComponents = colorString.Split(',');
        int ColorR = int.Parse(colorComponents[0]);
        int ColorG = int.Parse(colorComponents[1]);
        int ColorB = int.Parse(colorComponents[2]);
        int ColorA = int.Parse(colorComponents[3]);
        Color color = new Color(ColorR, ColorG, ColorB, ColorA);
        _background.color = color;
    }
}