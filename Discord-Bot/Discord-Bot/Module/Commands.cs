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

    
    
    [Command("Show Profile")]
    private async Task ShowProfile()
    {
        
        
    }

}