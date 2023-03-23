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
    [SerializeField]
    private GameObject playerCarsParent;

    private Button newCarButton;
    private TMP_Text speedText, handlingText, accelerationText, coolnessText;
    private Slider speedSlider, handlingSlider, accelerationSlider, coolnessSlider;

    // Start is called before the first frame update
    void Awake()
    {
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
        GameEventsPublisher.current.OnCreatedNewCar += OnCreatedNewCar; ;

        newCarButton.onClick.AddListener(CreateNewCarPressed);
    }

    private void OnCreatedNewCar(GameObject newCar)
    {
        GameObject temp = Instantiate(newCarPanel, playerCarsParent.transform);
        Texture2D carImage = AssetPreview.GetAssetPreview(newCar);
        Sprite carImageSprite = Sprite.Create(carImage, new Rect(0, 0, carImage.width, carImage.height), new Vector2(0.5f, 0.5f));
        Image carSlotImage = temp.transform.Find("Image_CarImg").GetComponent<Image>();
        carSlotImage.sprite = carImageSprite;
    }

    public void UpdateCarStatsUI(Car selectedCar)
    {
        speedText.text = selectedCar.maxSpeed.ToString();
        handlingText.text = selectedCar.handling.ToString();
        accelerationText.text = selectedCar.acceleration.ToString();
        coolnessText.text = selectedCar.coolness.ToString();

        speedSlider.value = selectedCar.maxSpeed;
        handlingSlider.value = selectedCar.handling;
        accelerationSlider.value = selectedCar.acceleration;
        coolnessSlider.value = selectedCar.coolness;
    }

    public void CreateNewCarPressed() 
    {
        GameEventsPublisher.current.CreateNewCar();
    }
}
