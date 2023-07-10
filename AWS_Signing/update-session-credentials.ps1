param(
    [string]$serialNumber,
    [string]$token,
    [string]$constantProfile,
    [string]$profile
)

if (Test-Path session.json) { Remove-Item session.json }
aws sts get-session-token --profile $constantProfile --serial-number $serialNumber --token-code $token >> session.json
$tokenResponse = Get-Content session.json -Raw | ConvertFrom-Json
if (Test-Path session.json) { Remove-Item session.json }

if ($tokenResponse) {
aws configure set --profile $profile aws_access_key_id $tokenResponse.Credentials.AccessKeyId
aws configure set --profile $profile aws_secret_access_key $tokenResponse.Credentials.SecretAccessKey
aws configure set --profile $profile aws_session_token $tokenResponse.Credentials.SessionToken
}