﻿using NUnit.Framework;
using model;
using model.cards;
using System.Collections.Generic;
using tests.observers;

namespace tests
{
    public class CorpActionCardTest
    {
        [Test]
        public void ShouldClickForCredit()
        {
            var game = new Game(new Decks().DemoCorp(), new Deck(new List<Card>()));
            game.Start();
            var balance = new LastBalanceObserver();
            var clicks = new SpentClicksObserver();
            game.corp.credits.Observe(balance);
            game.corp.clicks.Observe(clicks);
            var clickForCredit = game.corp.actionCard.credit;

            clickForCredit.Trigger(game);

            Assert.AreEqual(6, balance.LastBalance);
            Assert.AreEqual(1, clicks.Spent);
        }
    }
}