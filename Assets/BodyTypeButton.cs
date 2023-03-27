using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyTypeButton : MonoBehaviour
{
    [SerializeField]
    int id;
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { GameEventsPublisher.current.ApplyBodyType(id); });
    }
}
