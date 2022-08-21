using System.Threading.Tasks;
using Discord;
using Discord.Commands;


namespace Discord_Bot.Module;
public class Commands : ModuleBase<SocketCommandContext>
{
    
    //Exple of command function
    [Command("help")]
    private async Task Help()
    {
        var EmbedBuilderHelp = new EmbedBuilder()
            .WithTitle("Help List")
            .WithDescription("1.show profile \n 2.help");

        Embed embedHelp = EmbedBuilderHelp.Build();
        
        await ReplyAsync(embed: embedHelp);
    }

    [Command("description")]
    private async Task BotDescription()
    {

        var EmbedBuilderDescriptiom = new EmbedBuilder()
            .WithTitle("Description of Ardx Bot V2")
            .WithDescription("I am Ardx Bot V2 developed by Ardx3000 in .NET.\n " +
                             "My main function is to provide a competitive environment in different discord servers where players can challenge each other to different games and gain elo points. \n" +
                             "I do provide administration functionalities as well.\n " +
                             "I am still in development.")
            .WithFooter(footer =>
            {
                footer.WithText("Created by: Ardx3000");

            });
        Embed embedDescription = EmbedBuilderDescriptiom.Build();

        await ReplyAsync(embed: embedDescription);

    }

    

}