# BitTorrentFileServer

This is a learning project focused on Web technologies and F# development. F# is used where functional programming can be beneficial.
The application gives and alternative file transfer service for unreliable networks where connection can be slow or not at all for short periods of time. To solve the problem the application uses BitTorrent protocol. It can be used beside SMB/FTP especially with mobile clients.


## Specification

The application gives a UI for browsing files/folder on the server. After selecting them the app will create a torrent file containing the selected files/folder and starts seeding it. The user can download the torrent file and download the content.


## Projects

The repo contains the same application written in different languages/technologies/frameworks. 
All the projects uses Bootstrap for UI and primarily CSS Grid for layout.

* C#
    * Blazor: Single Page Application with Blazor framework
    * Razor Pages: ASP NET Core 2.2 application with Razor Pages
        * jQuery 
        * Javascript
        * Gulp for SCSS
* F#
    * Bolero: Single Page Application framework based on Blazor for F#
* Web
    * Angular: Angular based SPA
    * Vue:  Vue based SPA
        * Webpack for Vue SFC, bundling, static html copy
        * Gulp for several SCSS

The Web projects use ASP NET Core Web API as backend.  
Most of the projects use a common F# project (BitTorrentFileServer.Common.FSharp) for basic data structures and logic. There is also a common C# project (BitTorrentFileServer.Common.CSharp) for specific data and logic but it is mostly empty.  
The Bolero app uses a shared F# library (BitTorrentFileServer.FSShared) for the client and server side.  

## Current status
Blazor: -  
Razor Pages: UI, browse  
Bolero: initial steps  
Angular: -  
Vue: UI, browse  
