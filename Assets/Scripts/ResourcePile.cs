using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    private float _productionSpeed = 0.5f;
    public float ProductionSpeed
    {
        get { return _productionSpeed; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Non puoi impostare una velocit� di produzione negativa");
            }
            else
            {
                _productionSpeed = value;
            }
        }
    }

    private float m_CurrentProduction = 0.0f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }

        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += _productionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {_productionSpeed}/s";

    }


}
