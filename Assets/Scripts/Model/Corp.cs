﻿using model.cards;
using model.play.corp;
using model.player;
using model.zones.corp;

namespace model
{
    public class Corp
    {
        public readonly IPilot pilot;
        public readonly ActionCard actionCard;
        public readonly Zones zones;
        public readonly ClickPool clicks;
        public readonly CreditPool credits;
        public readonly Card identity;

        public Corp(
            IPilot pilot,
            ActionCard actionCard,
            Zones zones,
            ClickPool clicks,
            CreditPool credits,
            Card identity
        )
        {
            this.pilot = pilot;
            this.actionCard = actionCard;
            this.zones = zones;
            this.clicks = clicks;
            this.credits = credits;
            this.identity = identity;
        }

        public void Start(Game game)
        {
            pilot.Play(game);
            credits.Gain(5);
            zones.rd.Shuffle();
            zones.rd.Draw(5, zones.hq);
        }
    }
}