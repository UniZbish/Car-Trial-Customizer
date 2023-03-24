using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialButton : MonoBehaviour
{
    [SerializeField]
    int id;
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { GameEventsPublisher.current.ApplyPaintJob(id); });
    }
}
