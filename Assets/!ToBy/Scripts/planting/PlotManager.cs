using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;

    [SerializeField]
    Sprite[] plantStages;
    int plantStage = 0;
    float timeBtwStages = 1;
    float timer;

    private void Start() => plant = transform.GetChild(0).GetComponent<SpriteRenderer>();

    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < plantStages.Length - 1)
            {
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            //if (plantStage == plantStages.Length - 1)
            //{
            //    Harvest();
            //}
        }
        else
        {
            Plant();
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        isPlanted = true;

        plantStage = 0;
        UpdatePlant();
        timer = timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }

}