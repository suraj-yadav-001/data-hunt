﻿using UnityEngine;
using model.cards;
using model.zones.runner;

namespace view.log
{
    public class GripLog : IGripAdditionObserver, IGripRemovalObserver
    {
        void IGripAdditionObserver.NotifyCardAdded(Card card)
        {
            Debug.Log("Adding " + card + " to the grip");
        }

        void IGripRemovalObserver.NotifyCardRemoved(Card card)
        {
            Debug.Log("Removed " + card + " from the grip");
        }
    }
}