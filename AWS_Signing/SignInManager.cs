using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AWSSigning
{
    public class Credentials
    {
        public string AccessKeyId { get; set; }

        public string SecretAccessKey { get; set; }

        public string SessionToken { get; set; }

        public string Expiration { get; set; }
    }
    public class AWS
    {
        public Credentials Credentials { get; set; }
    }

    public static class SignInManager
    {
        public static bool SignIn(string token)
        {
            // setup AWS session token
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = "CMD.exe";
            pProcess.StartInfo.Arguments = $"/C aws sts get-session-token --profile {appSettings.ConstantProfileName} --serial-number {appSettings.MfaArn} --token-code {token}";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            var aws = JsonConvert.DeserializeObject<AWS>(strOutput);
            if (aws is null)
            {
                return false;
            }
            var lines = File.ReadAllLines(appSettings.CredentialsPath);
            var accessKeyId = $"aws_access_key_id = {aws.Credentials.AccessKeyId}";
            var secretAccessKey = $"aws_secret_access_key = {aws.Credentials.SecretAccessKey}";
            var sessionToken = $"aws_session_token = {aws.Credentials.SessionToken}";
            using (var sw = new StreamWriter(appSettings.CredentialsPath, false, System.Text.Encoding.Default))
            {
                for (var i = 0; i < lines.Length; i++)
                {
                    var line = i + 1;
                    if (appSettings.AwsAccessKeyIdLine == line)
                    {
                        sw.WriteLine(accessKeyId);
                    }
                    else if (appSettings.AwsSecretAccessKeyLine == line)
                    {
                        sw.WriteLine(secretAccessKey);
                    }
                    else if (appSettings.AwsSessionTokenLine == line)
                    {
                        sw.WriteLine(sessionToken);
                    }
                    else
                    {
                        sw.WriteLine(lines[i]);
                    }
                }
            }

            if (appSettings.IsSetupCodeArtifactNugetSource)
            {
                // add nuget source for axs codeartifact
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"powershell.exe";
                startInfo.Arguments = @"& './add-axs-codeartifact-nuget-source.ps1'";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                var errorOutput = process.StandardError.ReadToEnd();

                return errorOutput.Length == 0;
            }

            return true;
        }
    }
}
