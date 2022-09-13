# AWSSigning
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
region=us-west-2
```
Example of appSettings.json:
```
{
  "MfaArn": "MFA_ARN_FROM_AWS",
  "CredentialsPath": "C:\\Users\\USERNAME\\.aws\\credentials",
  "ConstantProfileName": "def",
  "IsSetupCodeArtifactNugetSource": true,
  "AwsAccessKeyIdLine": 7,
  "AwsSecretAccessKeyLine": 8,
  "AwsSessionTokenLine": 9
}
```
