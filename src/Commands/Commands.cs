using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace _UnderwaterBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

     
        [Command("gofish")]
        public async Task GoFish()
        {
            var embed = new EmbedBuilder();
            embed.WithDescription("");
            embed.WithFooter($"{Context.User.Username} ", Context.User.GetAvatarUrl());
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }


        [Command("tag")]
        public async Task Hello(SocketUser user) // Tags another user
        {

            await Context.Channel.SendMessageAsync($"{user.Mention}");

        }
    }
}

