using TMPro;
using UnityEngine;

public class InGame_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject winMenu;

    [SerializeField]
    private TMP_Text seed_Num;
    [SerializeField]
    private TMP_Text winSeed_Num;

    private LevelManager levelManager;

    private void Awake() => levelManager = LevelManager.instance;


    private void Update()
    {
        if(levelManager.IsAllLettersGood() || levelManager.IsAllLettersbad())
        {
            winSeed_Num.text = (PlayerPrefs.GetInt("Good Seed") + PlayerPrefs.GetInt("Bad Seed")).ToString();
            winMenu.SetActive(true);
        }

        seed_Num.text = (PlayerPrefs.GetInt("Good Seed") + PlayerPrefs.GetInt("Bad Seed")).ToString();

    }
}
