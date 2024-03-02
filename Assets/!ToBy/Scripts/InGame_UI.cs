using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject winMenu;

    [SerializeField]
    private TMP_Text seed_Num;
    [SerializeField]
    private TMP_Text winSeed_Num;

    [SerializeField]
    AudioSource BGSound;


    private LevelManager levelManager;

    private void Awake() => levelManager = LevelManager.instance;


    private void Update()
    {
        if(levelManager.IsAllLettersGood() || levelManager.IsAllLettersbad())
        {
            winSeed_Num.text = (PlayerPrefs.GetInt("Good Seed") + PlayerPrefs.GetInt("Bad Seed")).ToString();
            Invoke(nameof(win), 1);
        }

        seed_Num.text = (PlayerPrefs.GetInt("Good Seed") + PlayerPrefs.GetInt("Bad Seed")).ToString();

    }

    void win()
    {
        winMenu.SetActive(true);
    }


    public void Home()
    {
        SceneManager.LoadScene(0);
    }


    public void Mute()
    {
        BGSound.Pause();
        //BGSound.Play();
    }
    public void UnMute()
    {
        //BGSound.Pause();
        BGSound.Play();
    }
}
