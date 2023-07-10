namespace AWSSigning;

public class AppSettings
{
    public string MfaArn { get; set; }

    public string ConstantProfileName { get; set; } = "def";

    public string ProfileName { get; set; } = "default";

    public bool IsSetupSessionCredentials { get; set; } = true;

    public bool IsSetupCodeArtifactNugetSource { get; set; } = true;

    public bool IsSetupNpm { get; set; } = false;

    public string Domain { get; set; }

    public string DomainOwner { get; set; }

    public string Region { get; set; } = "us-west-2";

    public string NugetSourceName { get; set; } = "your/nuget";
}
