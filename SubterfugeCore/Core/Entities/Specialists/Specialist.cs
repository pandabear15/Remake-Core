﻿using Microsoft.Xna.Framework;
using SubterfugeCore.Components;
using SubterfugeCore.Core.Entities.Specialists.Effects;
using SubterfugeCore.Core.Interfaces.Outpost;
using SubterfugeCore.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubterfugeCore.Core.Entities.Specialists
{
    public class Specialist : IOwnable
    {
        int priority;
        String specialistName;
        Player owner;
        List<ISpecialistEffect> specialistEffects = new List<ISpecialistEffect>();

        public Specialist(String name, int priority, Player owner)
        {
            this.specialistName = name;
            this.priority = priority;
            this.owner = owner;
        }

        public List<ISpecialistEffect> getSpecialistEffects()
        {
            return this.specialistEffects;
        }

        public void removeSpecialistEffect(ISpecialistEffect effect)
        {
            if(specialistEffects.Contains(effect))
            {
                specialistEffects.Remove(effect);
            }
        }

        public void addSpecialistEffect(ISpecialistEffect effect)
        {
            specialistEffects.Add(effect);
        }

        public void applyEffect(ICombatable friendly, ICombatable enemy)
        {
            foreach(ISpecialistEffect effect in this.specialistEffects)
            {
                effect.forwardEffect(friendly, enemy);
            }
        }

        public void undoEffect(ICombatable friendly, ICombatable enemy)
        {
            foreach (ISpecialistEffect effect in this.specialistEffects)
            {
                effect.backwardEffect(friendly, enemy);
            }
        }

        public int getPriority()
        {
            return this.priority;
        }

        public Player getOwner()
        {
            return this.owner;
        }

        public void setOwner(Player newOwner)
        {
            this.owner = newOwner;
        }

        public void invoke(EffectTrigger trigger)
        {
            // Loop through specialist effects.
            // Determine if the effect should be triggered.
            foreach (ISpecialistEffect specialistEffect in this.specialistEffects)
            {
                if (specialistEffect.getEffectTrigger() == trigger)
                {
                    // specialistEffect.forwardEffect();
                }
            }
        }
    }
}
