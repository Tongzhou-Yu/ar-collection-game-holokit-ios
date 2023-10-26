using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadCounting : MonoBehaviour
{
    private Counting counting;
    public Button saveButton;
    public Button loadButton;
    public Button resetButton;
    public string loadSceneName;
    void Start()
    {
        counting = this.GetComponent<Counting>();
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
        resetButton.onClick.AddListener(Reset);
    }
    public void Save()
    {
        ES3.Save<int>("count", counting.collectedObjects);
    }
    public void Load()
    {
        counting.collectedObjects = ES3.Load<int>("count");
    }
    public void Reset()
    {
        ES3.DeleteKey("count");
        SceneManager.LoadScene(loadSceneName);
    }
}
