using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class ButtonEventTrigger : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private ButtonEventTrigger up;
    [SerializeField] private ButtonEventTrigger down;
    [SerializeField] private ButtonEventTrigger right;
    [SerializeField] private ButtonEventTrigger left;

    public ButtonEventTrigger GetDestination(Vector2 dir)
    {
        if (dir.sqrMagnitude == 0.0f) return null;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            return (dir.x > 0.0f) ? right : left; 
        }
        else
        {
            return (dir.y > 0.0f) ? up : down;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Click();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        ButtonController.SetCurrent(this);
    }

    public void Select()
    {
        selectSubject.OnNext(Unit.Default);
        OnSelect();
    }

    public void Deselect()
    {
        deselectSubject.OnNext(Unit.Default);
        OnDeselect();
    }

    public void Click()
    {
        clickSubject.OnNext(Unit.Default);
        OnClick();
    }

    protected virtual void OnSelect() { }
    protected virtual void OnDeselect() { }
    protected virtual void OnClick() { }
}

public partial class ButtonEventTrigger
{
    private Subject<Unit> clickSubject = new Subject<Unit>();
    public IObservable<Unit> Clicked => clickSubject;

    private Subject<Unit> selectSubject = new Subject<Unit>();
    public IObservable<Unit> Selected => selectSubject;

    private Subject<Unit> deselectSubject = new Subject<Unit>();
    public IObservable<Unit> Deselected => deselectSubject;
}