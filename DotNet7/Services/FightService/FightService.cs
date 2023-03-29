﻿using DotNet7.Data;
using DotNet7.Dtos.Fight;
using DotNet7.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet7.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext context;

        public FightService(DataContext context) {
            this.context = context;
        }

        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
        {
            var response = new ServiceResponse<AttackResultDto>();
            try
            {
                var attacker = await context.Characters
                    .Include(c => c.Weapon)
                    .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                var opponent = await context.Characters
                   .FirstOrDefaultAsync(c => c.Id == request.OpponentId);
            
             if (attacker is  null || opponent is null || attacker.Weapon is null) {
                    throw new Exception("Something is wrong");}
             
             int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
                damage -= new Random().Next(opponent.Defense);
                
             if (damage > 0)
                {
                    opponent.HitPoints -= damage;
                    response.Message = $"{opponent.Name} has been defeated";

                }

             await context.SaveChangesAsync();

                response.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    Opponent = opponent.Name,
                    AttackerHP = attacker.HitPoints,
                    OpponentHP = opponent.HitPoints,
                    Damage = damage,
                };
                

            } catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
