using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<GameObject> panelSlots;

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
        panelSlots = new List<GameObject>();

        GameEventsPublisher.current.OnCreatedNewCar += Current_OnCreatedNewCar;
        GameEventsPublisher.current.OnDisplayCarStats += DisplayCarStats;
        GameEventsPublisher.current.OnDeleteButtonClick += UpdateCarSlot;
        GameEventsPublisher.current.OnEditButtonClick += GetIndexOfSlot;

        newCarButton.onClick.AddListener(GameEventsPublisher.current.CreateNewCar);
    }

    private void GetIndexOfSlot(GameObject slot)
    {
        int index = panelSlots.IndexOf(slot);
        GameEventsPublisher.current.DiplayCarToEdit(index);
    }

    private void UpdateCarSlot(GameObject slot)
    {
        int index = panelSlots.IndexOf(slot);
        Destroy(panelSlots[index]);
        panelSlots.RemoveAt(index);
        GameEventsPublisher.current.DeleteCar(index);
    }

    private void DisplayCarStats(VehicleStats stat)
    {
        speedText.text = stat.maxSpeed.ToString();
        handlingText.text = stat.handling.ToString();
        accelerationText.text = stat.acceleration.ToString();
        coolnessText.text = stat.coolness.ToString();

        speedSlider.value = stat.maxSpeed;
        handlingSlider.value = stat.handling;
        accelerationSlider.value = stat.acceleration;
        coolnessSlider.value = stat.coolness;
    }

    private void Current_OnCreatedNewCar(GameObject newCar)
    {
        GameObject temp = Instantiate(newCarPanel, playerCarsParent.transform);
        
        TMP_Text carSlotText = temp.transform.Find("Text_CarName").GetComponent<TMP_Text>();
        carSlotText.text = "New Car";

        Image carSlotImage = temp.transform.Find("Image_CarImg").GetComponent<Image>();
        Texture2D carImage = AssetPreview.GetAssetPreview(newCar);
        carSlotImage.sprite = UpdateCarImage(carImage);
        panelSlots.Add(temp);
    }

    private Sprite UpdateCarImage(Texture2D carImage)
    {
        return Sprite.Create(carImage, new Rect(0, 0, carImage.width, carImage.height), new Vector2(0.5f, 0.5f));
    }

    private void OnDestroy()
    {
        GameEventsPublisher.current.OnCreatedNewCar -= Current_OnCreatedNewCar;
        GameEventsPublisher.current.OnDisplayCarStats -= DisplayCarStats;


        newCarButton.onClick.RemoveAllListeners();
    }
}
