using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    private ItemSlot[] itemSlots;

    [SerializeField]
    private Sprite greenLef;

    private void Start() => itemSlots = FindObjectsByType<ItemSlot>(FindObjectsSortMode.None);

    bool temp;
    private void Update()
    {
        if (IsAllLettersGood() && !temp)
        {
            PlayerPrefs.SetInt("Good Seed", PlayerPrefs.GetInt("Good Seed") + 1);
            foreach (var slot in itemSlots)
            {
                slot.drop.GetComponent<Image>().sprite = greenLef;
            }
            temp = true;
        }
        if (IsAllLettersbad() && !temp)
        {
            PlayerPrefs.SetInt("Bad Seed", PlayerPrefs.GetInt("Bad Seed") + 1);
            temp = true;
        }
    }


    public bool IsAllLettersGood()
    {
        foreach (ItemSlot item in itemSlots)
            if (item.isLettersGood == false)
                return false;

        return true;
    }
    public bool IsAllLettersbad()
    {
        foreach (ItemSlot item in itemSlots)
            if (item.isLettersBad == false)
                return false;

        return true;
    }
}
