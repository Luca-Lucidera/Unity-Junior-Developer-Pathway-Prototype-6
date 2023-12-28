using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile currentPile = null;

    [SerializeField] private float productivityMultiplier = 2f;

    protected override void BuildingInRange()
    {
        if (currentPile == null)
        {
            ResourcePile pile = target as ResourcePile;
            if (pile != null)
            {
                currentPile = pile;
                currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    private void ResetProductivity()
    {
        if (currentPile != null)
        {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target); // run method from base class
    }
    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
