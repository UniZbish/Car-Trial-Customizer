using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsPublisher : MonoBehaviour
{
    public static GameEventsPublisher current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnCreateNewCar;
    public void CreateNewCar()
    {
        OnCreateNewCar?.Invoke();
    }
    public event Action<GameObject> OnCreatedNewCar;
    public void CreatedNewCar(GameObject newCar) 
    {
        OnCreatedNewCar?.Invoke(newCar);
    }

    public event Action<GameObject> OnEditButtonClick;
    public void EditCar(GameObject slot) 
    {
        OnEditButtonClick?.Invoke(slot);
    }

    public event Action<int> OnEditSelectedCar;
    public void DiplayCarToEdit(int car)
    {
        OnEditSelectedCar?.Invoke(car);
    }

    public event Action<GameObject> OnDeleteButtonClick;
    public void DeleteCarSlot(GameObject slot)
    {
        OnDeleteButtonClick?.Invoke(slot);
    }
    public event Action<int> OnDeleteCar;
    public void DeleteCar(int id)
    {
        OnDeleteCar?.Invoke(id);
    }

    public event Action<VehicleStats> OnDisplayCarStats;
    public void DisplayCarStats(VehicleStats Stats)
    {
        OnDisplayCarStats?.Invoke(Stats);
    }

    public event Action<int> OnPaintJobChange;
    public void ApplyPaintJob(int materialIndex)
    {
        OnPaintJobChange?.Invoke(materialIndex);
    }

    public event Action<int> OnMaterialChanged;
    public void MaterialChanged(int id)
    {
        OnMaterialChanged?.Invoke(id);
    }
}
