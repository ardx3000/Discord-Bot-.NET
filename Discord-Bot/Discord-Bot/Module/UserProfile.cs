using System.Xml.Xsl;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord_Bot.Module.Utilities;

using MessageExtensions = Discord.Commands.MessageExtensions;

namespace Discord_Bot.Module;

public class UserProfile : ModuleBase<SocketCommandContext>
{
    private SocketMessage socketMessage;
    private TimeAndDate TnD = new TimeAndDate();
    private  JSONAdministration test = new JSONAdministration();
    
    private int points = 100;
    
    [Command("show profile")]
    private async Task ShowProfile(IGuildUser user = null)
    {
        var message = socketMessage;
        if (user == null)
        {
            // user = self; set the user as the caster of the command
        }



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


    [Command("TestJ")]
    private async Task TestJ()
    {
        
        test.JSONTest("XD");
        await ReplyAsync("Command has been executed !");
        
    }



}
