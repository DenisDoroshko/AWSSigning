namespace AWSSigning;

public class AppSettings
{
    public string MfaArn { get; set; }

    public string CredentialsPath { get; set; }

    public string ConstantProfileName { get; set; }

    public bool IsSetupCodeArtifactNugetSource { get; set; } = true;

    public int AwsAccessKeyIdLine { get; set; }

    public int AwsSecretAccessKeyLine { get; set; }

    public int AwsSessionTokenLine { get; set; }
}
