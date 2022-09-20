using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord_Bot.Module.Utilities;

namespace Discord_Bot.Module;

public class UserProfile : ModuleBase<SocketCommandContext>
{
    private SocketMessage socketMessage;
    private TimeAndDate TnD = new TimeAndDate();
    
    
    [Command("show profile")]
    private async Task ShowProfile(IGuildUser user = null)
    {
        if (user == null)
        {
           // user = self; set the user as the caster of the command
        }

        int points = 100;

        var EmbedBuilderUserProfile = new EmbedBuilder()
            .WithTitle($"{user}")
            .WithImageUrl(user.GetDisplayAvatarUrl())
            .WithDescription($"Points: {points}")
            .WithFooter(footer =>
            {
                footer.WithText("User: " + user + " " + "Requested at: " + TnD.Time);
            });
        
        Embed embedUP = EmbedBuilderUserProfile.Build();
        await ReplyAsync(embed: embedUP);
    }

    
}
