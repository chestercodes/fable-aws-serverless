
$apiEndpoint = "9nfublf0dj.execute-api.eu-west-1.amazonaws.com"
[System.Environment]::SetEnvironmentVariable('FAS_API_ENDPOINT_HOST', $apiEndpoint)

$s3Bucket = "fable-aws-serverless-site-chestercodes"
[System.Environment]::SetEnvironmentVariable('FAS_SITE_S3BUCKET', $s3Bucket)

# restore and build site
npm install
npm run build

# deploy cloudfront instance
serverless deploy

# copy deploy folder to S3
aws s3 sync deploy/ "s3://$s3Bucket/"
