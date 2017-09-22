using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace GithubViewer.IdSrv.Config
{
    internal static class Cert
    {
        public static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\githubviewer.idsrv.pfx"), "githubviewertest");
        }
    }
}