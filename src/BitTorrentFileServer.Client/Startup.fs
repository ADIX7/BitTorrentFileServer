namespace BitTorrentFileServer.Client

open Microsoft.AspNetCore.Blazor.Builder
open Microsoft.AspNetCore.Blazor.Hosting
open Microsoft.Extensions.DependencyInjection
open Main
open Bolero.Remoting

type Startup() =

    member __.ConfigureServices(services: IServiceCollection) =
        ClientRemotingExtensions.AddRemoting(services)

    member __.Configure(app: IBlazorApplicationBuilder) =
        app.AddComponent<FileServerApp>("#main")

module Program =

    [<EntryPoint>]
    let Main args =
        BlazorWebAssemblyHost.CreateDefaultBuilder()
            .UseBlazorStartup<Startup>()
            .Build()
            .Run()
        0
