# AWSSigning - Tool for simplifying setting app AWS session tokens and logging to AWS code artifact
Example of credentials file(in C:\Users\USERNAME\.aws\):
```
[def]
aws_access_key_id = AWS_ACCESS_KEY_ID_FROM_AWS
aws_secret_access_key = AWS_SECRET_ACESS_KEY_FROM_AWS
output=json
toolkit_artifact_guid=1652de2a-fda1-499f-b974-126991707728
[default]
aws_access_key_id = TEMPORARY_KEY_GENERATED_BY_TOOL
aws_secret_access_key = TEMPORARY_KEY_GENERATED_BY_TOOL
aws_session_token = TEMPORARY_KEY_GENERATED_BY_TOOL
toolkit_artifact_guid=1652de2a-fda1-499f-b974-126991707728
region=us-west-2
```
see template: [credentials template](https://github.com/DenisDoroshko/AWSSigning/blob/main/AWS_Signing/CredentialsTemplate)

Example of appSettings.json:
```
{
  "MfaArn": "MFA_ARN_FROM_AWS",
  "ConstantProfileName": "def",
  "ProfileName": "default",
  "IsSetupSessionCredentials": true,
  "IsSetupCodeArtifactNugetSource": true,
  "IsSetupNpm": false,
  "Domain": "COMPANY",
  "DomainOwner": "1234567",
  "Region": "us-west-2",
  "NugetSourceName": "COMPANY/nuget"
}
```
option **IsSetupSessionCredentials** updates AWS credentials using MFA token from two-factor application

option **IsSetupCodeArtifactNugetSource** allows to sign in to AWS code artifact for nuget packages support

option **IsSetupNpm** updates code artifact credentials for nmp(executes `aws codeartifact login --tool npm --repository npm --domain COMPANY --domain-owner 123456`)

options **MfaArn** stores mfa arn value that is used for getting session credentials, to get value:
Go to `Security credentials` tab in AWS configure MFA device(if not configured) and copy identifier:
![image](https://user-images.githubusercontent.com/71182505/189976814-e00fc4dd-3b70-4425-ba2d-1eb1c514e94e.png)

option **ConstantProfileName** stores profile with permanent credentials which should be used for getting session credentials with MFA,
to setup credentials for this profile:
Go to `Security credentials` tab and create them on `Access keys` tab and then paste them for [def] profile (`aws_access_key_id` and `aws_secret_access_key`)

option **ProfileName** stores profile to which credentials will be added
Powershell scripts most likely won't be allowed if you didn't run them before, run command `Set-ExecutionPolicy RemoteSigned -Scope CurrentUser -Force` in PowerShell to allow scripts execution

options **Domain**, **DomainOwner**, **Region** store settings for code artifact and can be retrieved in AWS, go to Code Artifact in needed region and see values for needed store:
![image](https://github.com/DenisDoroshko/AWSSigning/assets/71182505/d1ff48e1-92aa-4199-bbe5-edf62b430cdf)

option **NugetSourceName** stores name of nuget source that will be created to use for loading packages, for example in Visual Studio you will see your source in the list:
![image](https://github.com/DenisDoroshko/AWSSigning/assets/71182505/bb17093b-83d9-4a22-93bc-35ceae0b1185)
