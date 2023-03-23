using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControls : MonoBehaviour
{
    private int UILayer;

    [SerializeField]
    private int speed;
        
    private bool buttonUp;

    // Start is called before the first frame update
    void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            if (!AreWeOverUI(raycastResults) || buttonUp == false)
            {
                buttonUp = false;
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            buttonUp = true;
        };
    }

    private bool AreWeOverUI(List<RaycastResult> eventSystemRaycastResult) 
    {
        for (int i = 0; i < eventSystemRaycastResult.Count; i++) 
        {
            RaycastResult currentRaycastResult = eventSystemRaycastResult[i];
            if (currentRaycastResult.gameObject.layer == UILayer) 
            {
                return true;
            }
        }
        return false;
    }
}
