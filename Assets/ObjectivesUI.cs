using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectivesUI : MonoBehaviour
{
    [SerializeField] List<Objective> objectives = new List<Objective>();
    
    public void SetObjectiveComplete(ObjectiveType objectiveType)
    {
        foreach (var objective in objectives.Where(objective => objective.objectiveType == objectiveType))
        {
            objective.SetObjectiveComplete(true);
        }
    }
    
    public void PizzaDelivered()
    {
        SetObjectiveComplete(ObjectiveType.PizzaDelivered);
    }
    
    public void Escape()
    {
        SetObjectiveComplete(ObjectiveType.Escape);
    }
    
    public void ButtonPressed()
    {
        SetObjectiveComplete(ObjectiveType.ButtonPressed);
    }
    
    public void VaultOpen()
    {
        SetObjectiveComplete(ObjectiveType.VaultOpen);
    }
    
    public void MoneyTaken()
    {
        SetObjectiveComplete(ObjectiveType.MoneyTaken);
    }
}

[Serializable]
public struct Objective
{
    public TMP_Text objectiveName;
    public ObjectiveType objectiveType;

    public void SetObjectiveComplete(bool complete)
    {
        objectiveName.fontStyle = complete ? FontStyles.Strikethrough : FontStyles.Normal;
    }
} 

[Serializable]
public enum ObjectiveType
{
    ButtonPressed,
    VaultOpen,
    MoneyTaken,
    PizzaDelivered,
    Escape
}
