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
**How to get MFA arn?**

Go to `Security credentials` tab in AWS configure MFA device(if not configured) and copy identifier:
![image](https://user-images.githubusercontent.com/71182505/189976814-e00fc4dd-3b70-4425-ba2d-1eb1c514e94e.png)
**How to get access keys?**

Go to `Security credentials` tab and create them on `Access keys` tab and then paste them for [def] profile (`aws_access_key_id` and `aws_secret_access_key`)
