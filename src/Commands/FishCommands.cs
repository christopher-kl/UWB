﻿using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using UnderwaterBot.DAL;
using UnderwaterBot.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace UnderwaterBot.Modules
{
    public class FishCommands : ModuleBase<SocketCommandContext>
    {

        private readonly IFishRepository _fishService;
      
        public FishCommands(IFishRepository fishService)
        {
            _fishService = fishService;
        }
       
        [Command("fishadd")]
        public async Task FishAdd() // Initializes data to the database. Command not needed if EnsureDeleted is removed from Context file
        {

            var fish1 = new Fish
            {
                Fishes = "Example1",
                Rarity = "",
            };

            var fish2 = new Fish
            {
                Fishes = "Example2",
                Rarity = "",
            };

            var fish3 = new Fish
            {
                Fishes = "Example3",
                Rarity = "",
            };

            var fish4 = new Fish
            {
                Fishes = "Example4",
                Rarity = "",
            };

            using (var lite = new FishContext())
            {

                await lite.FishCollection.AddAsync(fish1);
                await lite.FishCollection.AddAsync(fish2);
                await lite.FishCollection.AddAsync(fish3);
                await lite.FishCollection.AddAsync(fish4);
                await lite.SaveChangesAsync();

                var total = lite.FishCollection.Count();
                await Context.Channel.SendMessageAsync($"{total} ");
            }

        }

        [Command("fishinfo")]
        public async Task FishInfo(string fishName)
        {
            
            Fish fish = await _fishService.GetFishByName(fishName).ConfigureAwait(false);

            if (fish == null)
            {
                await Context.Channel.SendMessageAsync($"{fishName}");
                return;
            }

            await Context.Channel.SendMessageAsync($"Name: {fish.Fishes}, Rarity: {fish.Rarity}");
        }
    }
}
    


