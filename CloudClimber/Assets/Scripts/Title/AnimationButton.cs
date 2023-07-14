using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnimationButton : ButtonEventTrigger
{
    Graphic graphic = null;
    [SerializeField]
    Color selectingColor = Color.white;

    Color defaultColor;

    private void Awake()
    {
        graphic = GetComponent<Graphic>();
        if (graphic) defaultColor = graphic.color;
    }

    protected override void OnSelect()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(1.1f, 0.1f))
            .Append(transform.DOScale(1.0f, 0.1f))
            .SetLink(gameObject);

        if (graphic)
        {
            graphic.DOColor(selectingColor, 0.1f).SetLink(gameObject);
        }
    }

    protected override void OnDeselect()
    {
        if (graphic) graphic.DOColor(defaultColor, 0.1f).SetLink(gameObject);
    }
}