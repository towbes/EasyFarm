﻿using System.Threading;
using EasyFarm.Classes;
using EliteMMO.API;
using MemoryAPI;

namespace EasyFarm.States
{
    public class DeadState : BaseState
    {
        public DeadState(IMemoryAPI fface) : base(fface) { }

        public override bool Check()
        {
            var status = fface.Player.Status;
            return status == Status.Dead1 || status == Status.Dead2;
        }

        public override void Run()
        {
            // Stop program from running to next waypoint.
            fface.Navigator.Reset();

            if (Config.Instance.HomePointOnDeath)
            {
                HomePointOnDeath();
            }

            // Stop the engine from running.
            AppServices.SendPauseEvent();
        }

        private void HomePointOnDeath()
        {
            Thread.Sleep(300);
            fface.Windower.SendKeyPress(Keys.NUMPADENTER);
            Thread.Sleep(300);
            fface.Windower.SendKeyPress(Keys.LEFT);
            Thread.Sleep(300);
            fface.Windower.SendKeyPress(Keys.NUMPADENTER);
        }
    }
}
