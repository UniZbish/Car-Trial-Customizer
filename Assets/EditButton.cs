using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Int32.TryParse(gameObject.transform.parent.name, out int result);
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { GameEventsPublisher.current.EditCar(result); });
    }
}
