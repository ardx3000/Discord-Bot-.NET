using Discord;
using Discord.Commands;
using Discord_Bot.Module.Utilities;

namespace Discord_Bot.Module;

public class AdministrativeCommands : ModuleBase<SocketCommandContext>
{
    

    private TimeAndDate TnD = new TimeAndDate();
    
    [Command("ban")]
    [RequireUserPermission(GuildPermission.BanMembers,
        ErrorMessage = "You do not have the permission to ban members!")]

    private async Task Ban(IGuildUser user = null, [Remainder] string reason = null)
    {
        if (user == null)
        {
            await ReplyAsync("Specify a user!");
            return;
        }

        if (reason == null) reason = "Happens XD";

        await Context.Guild.AddBanAsync(user, 0, reason);
        
        
        var EmbedBuilderBan = new EmbedBuilder()
            .WithDescription($":red_check_mark: {user.Mention} was banned \n **Reason: **{reason}")
            .WithFooter(footer =>
            {
                footer
                    .WithText("User banned at: " + TnD.Time);
            });
        Embed embedBan = EmbedBuilderBan.Build();
        await ReplyAsync(embed: embedBan);
    }

    [Command("unban")]
    [RequireUserPermission(GuildPermission.BanMembers,
        ErrorMessage = "You do not have the permission to unban members!")]

    private async Task Unban(IGuildUser user = null, [Remainder] string reason = null)
    {
        if (user == null)
        {
            await ReplyAsync("Specify a user!");
            return;
        }
        await Context.Guild.RemoveBanAsync(user);

    }


    [Command("kick")]
    [RequireUserPermission(GuildPermission.KickMembers,
        ErrorMessage = " You do not have the permission to kick members")]

    private async Task Kick(IGuildUser user = null, [Remainder] string reason = null)
    {
        if (user == null)
        {
            await ReplyAsync("Specify a user!");
            return;
        }

        if (reason == null) reason = "Happens XD";

        await user.KickAsync(reason);
        await ReplyAsync(user + "Has been kicked at: " + TnD.Time);
    }

}