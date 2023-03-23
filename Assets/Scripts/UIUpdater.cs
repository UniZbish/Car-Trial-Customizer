using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject newCarPanel;
    private GameObject playerCarsParent;

    private Button newCarButton;
    private TMP_Text speedText, handlingText, accelerationText, coolnessText;
    private Slider speedSlider, handlingSlider, accelerationSlider, coolnessSlider;

    // Start is called before the first frame update
    void Awake()
    {
        playerCarsParent = GameObject.Find("Panel_PlayerCars");

        newCarButton = GameObject.Find("Button_AddNewCar").GetComponent<Button>();

        speedText = GameObject.Find("SpeedNumberText").GetComponent<TMP_Text>();
        handlingText = GameObject.Find("HandlingNumberText").GetComponent<TMP_Text>();
        accelerationText = GameObject.Find("AccelerationNumberText").GetComponent<TMP_Text>();
        coolnessText = GameObject.Find("CoolnessNumberText").GetComponent<TMP_Text>();

        speedSlider = GameObject.Find("SliderCarSpeed").GetComponent<Slider>();
        handlingSlider = GameObject.Find("SliderCarHandling").GetComponent<Slider>();
        accelerationSlider = GameObject.Find("SliderCarAcceleration").GetComponent<Slider>();
        coolnessSlider = GameObject.Find("SliderCarCoolness").GetComponent<Slider>();
    }
    public void Start()
    {
        GameEventsPublisher.current.OnCreatedNewCar += Current_OnCreatedNewCar;
        GameEventsPublisher.current.OnDisplayCar += DisplayCarStats;

        newCarButton.onClick.AddListener(GameEventsPublisher.current.CreateNewCar);
    }

    private void DisplayCarStats(Car car)
    {
        speedText.text = car.maxSpeed.ToString();
        handlingText.text = car.handling.ToString();
        accelerationText.text = car.acceleration.ToString();
        coolnessText.text = car.coolness.ToString();

        speedSlider.value = car.maxSpeed;
        handlingSlider.value = car.handling;
        accelerationSlider.value = car.acceleration;
        coolnessSlider.value = car.coolness;
    }

    private void Current_OnCreatedNewCar(GameObject newCar)
    {
        GameObject temp = Instantiate(newCarPanel, playerCarsParent.transform);
        temp.name = (playerCarsParent.transform.childCount - 1).ToString();
        Texture2D carImage = AssetPreview.GetAssetPreview(newCar);
        Sprite carImageSprite = Sprite.Create(carImage, new Rect(0, 0, carImage.width, carImage.height), new Vector2(0.5f, 0.5f));
        Image carSlotImage = temp.transform.Find("Image_CarImg").GetComponent<Image>();
        carSlotImage.sprite = carImageSprite;
    }

    private void OnDestroy()
    {
        GameEventsPublisher.current.OnCreatedNewCar -= Current_OnCreatedNewCar;
        GameEventsPublisher.current.OnDisplayCar -= DisplayCarStats;


        newCarButton.onClick.RemoveAllListeners();
    }
}
