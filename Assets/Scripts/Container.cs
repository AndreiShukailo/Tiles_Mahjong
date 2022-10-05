using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Container : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Transform _field;

    private List<Card> _cards = new List<Card>();
    private UI _ui;

    private void Start()
    {
        _ui = FindObjectOfType<UI>();
    }

    public void TryAddToContainer(Card card)
    {
        if (_cards.Count < 7)
        {
            _cards.Add(card);

            Transform point = _points[_cards.IndexOf(card)];

            card.MoveCardToContainer(point);

            CheckMatches(card);

            CheckLoose();
        }

    }

    private void CheckMatches(Card card)
    {
        int matches = _cards.Count(item => item.Lable == card.Lable);

        if (matches >= 3)
        {
            StartCoroutine(RemoveMathes(card));
        }
    }

    IEnumerator RemoveMathes(Card card)
    {
        for (int i = 0; i < 3; i++)
        {
            Card removeCard = _cards.Find(item => item.Lable == card.Lable);
            _cards.Remove(removeCard);
            Destroy(removeCard.gameObject, 0.2f);    
        }
        
        yield return new WaitForSeconds(0.2f);

        RenderContainer();

        if (_field.childCount <= 0)
            _ui.ActiveVictoryScene();
    }

    private void RenderContainer()
    {
        for (int i = 0; i < _cards.Count; i++)
            _cards[i].MoveCardToContainer(_points[i]);
    }

    private void CheckLoose()
    {
        if (_cards.Count >= 7)
            _ui.ActiveDefeatScene();
    }
}
