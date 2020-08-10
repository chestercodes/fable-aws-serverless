module AwsTypes

type IdentityContext = {
  cognitoIdentityPoolId: Fable.Core.JS.Object
  cognitoIdentityId: Fable.Core.JS.Object
  apiKey: string // e.g. 'test-invoke-api-key',
  principalOrgId: Fable.Core.JS.Object
  cognitoAuthenticationType: Fable.Core.JS.Object
  userArn: string // e.g. 'arn:aws:iam::XXXXX:user/XXXXX',
  apiKeyId: string // e.g. 'test-invoke-api-key-id',
  userAgent: string //e.g. 'aws-internal/3 aws-sdk-java/1.11.820 Linux/4.9.217-0.1.ac.205.84.332.metal1.x86_64 OpenJDK_64-Bit_Server_VM/25.252-b09 java/1.8.0_252 vendor/Oracle_Corporation',
  accountId: string // e.g. 'XXXXX',
  caller: string // e.g. 'ACCESSKEYXXXXX',
  sourceIp: string // e.g. 'test-invoke-source-ip',
  accessKey: string // e.g. 'XXXXXXXXXXXXXXX',
  cognitoAuthenticationProvider: Fable.Core.JS.Object
  user: string //e.g. 'ACCESSKEYXXXXXXX'
}

type ApiGatewayRequestContext = {
  resourceId: string //e.g. '8567bf'
  resourcePath: string //e.g. '/greeting/hello'
  httpMethod: string //e.g. 'GET',
  extendedRequestId: string //e.g. 'QgJtqHktjoEFhPA=',
  requestTime: string //e.g. '30/Jul/2020:19:44:36 +0000',
  path: string //e.g. '/greeting/hello',
  accountId: string //'XXXXXXXXXXXX',
  protocol: string //e.g. 'HTTP/1.1',
  stage: string //e.g. 'test-invoke-stage',
  domainPrefix: string //e.g. 'testPrefix',
  requestTimeEpoch: int //e.g. 1596138276155,
  requestId: string //e.g. 'd38ef699-511d-4306-880d-fbff66862eb5',
  identity: IdentityContext
  domainName: string //e.g. 'testPrefix.testDomainName',
  apiId: string //e.g. '3f0x3a9jgi'

}

type ApiGatewayEvent = {
  resource: string //e.g. '/greeting/hello',
  path: string //e.g. '/greeting/hello',
  httpMethod: string //e.g. 'GET',
  headers: Fable.Core.JS.Object //e.g. null,
  multiValueHeaders: Fable.Core.JS.Object // e.g. null,
  queryStringParameters: Fable.Core.JS.Object // e.g. null or { thing1: '123', thing2: 'abc' }
  multiValueQueryStringParameters: Fable.Core.JS.Object // e.g. null or { thing1: [ '123' ], thing2: [ 'abc' ] }
  pathParameters: Fable.Core.JS.Object //e.g. null or { id: '123' },
  stageVariables: Fable.Core.JS.Object //e.g. null,
  requestContext: ApiGatewayRequestContext
  body: string
  isBase64Encoded: bool
}

type ApiGatewayLambdaProxyResponse = {
    isBase64Encoded: bool
    statusCode: int
    headers: Fable.Core.JS.Object
    body: string // body needs to be stringified
}

type AwsLambdaContext =
  {
    succeed: ApiGatewayLambdaProxyResponse -> unit
    fail: ApiGatewayLambdaProxyResponse -> unit
    ``done``: ApiGatewayLambdaProxyResponse -> unit
    functionVersion: string //e.g. '$LATEST',
    functionName: string //e.g. 'services-dev-getHello',
    memoryLimitInMB: string //e.g. '1024',
    logGroupName: string //e.g. '/aws/lambda/services-dev-getHello',
    logStreamName: string //e.g. '2020/07/30/[$LATEST]bff553bdea6840d19ac3f3c8b05dadd4',
    clientContext: Fable.Core.JS.Object // TODO undefined,
    identity: Fable.Core.JS.Object // TODO undefined,
    invokedFunctionArn: string //e.g. 'arn:aws:lambda:eu-west-1:XXXXXXXX:function:services-dev-getHello',
    awsRequestId: string //e.g. 'e83e4535-b7df-4dbd-b900-d86160c29bd7'
  }
