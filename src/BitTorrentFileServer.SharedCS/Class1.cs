using System;
using Bolero.Remoting;

namespace BitTorrentFileServer.SharedCS
{
    public class Class1 : IRemoteService
    {
        public string BasePath { get; } = "api";
    }

    public class Class2
    {
        public Class2()
        {
            var a = new BitTorrentFileServer.Service.WebService(null);

            IRemoteService b = (IRemoteService)a;

            Console.WriteLine(b.BasePath);
        }
    }
}
