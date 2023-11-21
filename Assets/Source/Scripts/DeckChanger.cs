using UnityEngine;
using UnityEngine.EventSystems;

public class DeckChanger : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
       // if(Input.GetMouseButton(0))
          // CreateRay();
    }

    /*private void CreateRay()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            var item = hit.collider.GetComponent<Item>();
            Debug.Log(item);
            if (item && EventSystem.current.IsPointerOverGameObject()) ;
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
               Debug.Log(item);
                item.transform.localPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,1);
            }
        }
    }*/
}
