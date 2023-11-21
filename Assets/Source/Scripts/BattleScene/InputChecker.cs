using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputChecker : MonoBehaviour
{
    public static Action MobInField;
    [SerializeField] private MobsPool _pool;
    [SerializeField] private Inventory _inventory;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        CreateRay();
    }

    private void CreateRay()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
       
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            var plane = hit.collider.GetComponent<Plane>();
            
            if (plane)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                
                UseMob(hit.point);  
            }
        }
    }

    private void UseMob(Vector3 positionOfmOb)
    {
        if (Input.GetMouseButtonDown(0) & _inventory.ItemType != null)
        {
            _pool.GetFreeElement(positionOfmOb);
            MobInField?.Invoke();
        }
    }
}
