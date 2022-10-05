using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class Card : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private string _lable;
    [SerializeField] private GameObject _blackOut;

    private Container _container;

    public string Lable => _lable;

    private bool _activeSelf = true;
    private BoxCollider _colider;
    private Vector3 _rayPosition;

    private void Start()
    {
        _colider = GetComponent<BoxCollider>();
        _rayPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);
        _container = FindObjectOfType<Container>();
    }
    private void Update()
    {
        if (Physics.Raycast(_rayPosition, transform.forward, out var hitInfo, 0.3f) && hitInfo.collider.TryGetComponent<Card>(out Card component))
        {
            if (_activeSelf)
                SetActive(false);
        }
        else SetActive(true);
            
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == 0)
        {
            _container.TryAddToContainer(this);
        }
    }

    private void SetActive(bool isActive)
    {
        _blackOut.SetActive(!isActive);
        _colider.enabled = isActive;
        _activeSelf = isActive;
    }

    public void MoveCardToContainer(Transform point)
    {
        transform.DOMove(point.position, 0.1f);
        _colider.enabled = false;
        gameObject.layer = 0;
    }
}
