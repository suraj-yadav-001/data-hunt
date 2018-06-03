﻿using model.costs;
using model.effects.runner;
using model.cards;
using System.Threading.Tasks;

namespace model.play.runner
{
    public class ActionCard : IResolutionObserver
    {
        public readonly Ability draw;
        public readonly Ability credit;
        private TaskCompletionSource<bool> actionTaking;
        private ActionPermission permission = new ActionPermission();

        public ActionCard()
        {
            draw = new Ability(new Conjunction(new RunnerClickCost(1), permission), new Draw(1));
            draw.ObserveResolution(this);
            credit = new Ability(new Conjunction(new RunnerClickCost(1), permission), new Gain(1));
            credit.ObserveResolution(this);
        }

        public Ability Play(Card card)
        {
            Ability play = new Ability(new Conjunction(new RunnerClickCost(1), card.PlayCost, permission), new Play(card));
            play.ObserveResolution(this);
            return play;
        }

        public Ability Install(Card card)
        {
            Ability install = new Ability(new Conjunction(new RunnerClickCost(1), card.PlayCost, permission), new Install(card));
            install.ObserveResolution(this);
            return install;
        }

        async public Task TakeAction()
        {
            permission.Grant();
            actionTaking = new TaskCompletionSource<bool>();
            await actionTaking.Task;
            permission.Revoke();
        }

        void IResolutionObserver.NotifyResolved()
        {
            actionTaking.SetResult(true);
        }
    }
}