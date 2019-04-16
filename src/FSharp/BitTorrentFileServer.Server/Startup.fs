namespace BitTorrentFileServer.Server

open System
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Bolero.Templating.Server
open BitTorrentFileServer
open Bolero.Remoting.Server
open System.IO
open BitTorrentFileServer.Functions
open BitTorrentFileServer.Service

type Startup() =

    let webSerivce = 
        { 
            getFolders = fun () -> async {
                return getFolderByDirectory(DirectoryInfo("testData"))
            }
        }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    member this.ConfigureServices(services: IServiceCollection) =
        services.AddRemoting(webSerivce)
#if DEBUG
            .AddHotReload(templateDir = "../BitTorrentFileServer.Client/wwwroot")
#endif
        |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        app.UseRemoting()
#if DEBUG
            .UseHotReload()
#endif
            .UseBlazor<Client.Startup>()
        |> ignore

module Program =

    [<EntryPoint>]
    let main args =
        WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build()
            .Run()
        0
