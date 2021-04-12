using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform _selection;

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            foreach (Transform child in _selection)
            {
                var outline = child.GetComponent<Outline>();
                outline.enabled = false;
            }
            _selection = null;
        }

        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        var ray = Camera.main.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if(selection.CompareTag("Selectable"))
            {
                _selection = selection;
                foreach (Transform child in _selection)
                {
                    var outline = child.GetComponent<Outline>();
                    if (outline != null)
                        outline.enabled = true;
                }              
            }
        }
    }
}
