using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace AWSSigning
{
    public static class SignInManager
    {
        public static (bool Result, string ErrorMessage) SignIn(string token)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);

            if (appSettings.IsSetupSessionCredentials) 
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"powershell.exe";
                startInfo.Arguments = $"./update-session-credentials.ps1 {appSettings.MfaArn} {token} {appSettings.ConstantProfileName} {appSettings.ProfileName}";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                var errorOutput = process.StandardError.ReadToEnd();

                if (errorOutput.Length != 0) 
                {
                    return (false, $"Failed session credentials setup {errorOutput}");
                }
            }

            if (appSettings.IsSetupCodeArtifactNugetSource)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"powershell.exe";
                startInfo.Arguments = $"./add-codeartifact-nuget-source.ps1 {appSettings.Domain} {appSettings.DomainOwner}  {appSettings.Region} {appSettings.NugetSourceName}";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                var errorOutput = process.StandardError.ReadToEnd();

                if (errorOutput.Length != 0) 
                {
                    return (false, $"Failed nuget setup {errorOutput}");
                }
            }

            if (appSettings.IsSetupNpm)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"powershell.exe";
                startInfo.Arguments = $"./add-codeartifact-npm-source.ps1 {appSettings.Domain} {appSettings.DomainOwner} {appSettings.ProfileName}";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                var errorOutput = process.StandardError.ReadToEnd();

                if (errorOutput.Length != 0) 
                {
                    return (false, $"Failed npm setup {errorOutput}");
                }
            }

            return (true, null);
        }
    }
}
