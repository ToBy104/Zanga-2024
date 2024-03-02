using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private ItemSlot[] itemSlots;

    private void Start() => itemSlots = FindObjectsByType<ItemSlot>(FindObjectsSortMode.None);

    bool temp;
    private void Update()
    {
        if (IsAllLettersGood() && !temp)
        {
            PlayerPrefs.SetInt("Good Seed", PlayerPrefs.GetInt("Good Seed") + 1);
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
