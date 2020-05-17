# JsonParserDemo

![.NET Core](https://github.com/typesafedev/JsonParserDemo/workflows/.NET%20Core/badge.svg)

## Also demos how to setup a CI pipeline using Github Actions.
  - Sets env variables at workflow level.
  - Builds using agent running latest ubuntu
  - Using dotnet core 3.1
  - Checkout code
  - Restore dependencies - nuget because .net
  - Build code in release configuration
  - Runs all tests in repo and produce raw code coverage file in coverage.cobertura.xml
  - Runs reportgenerator to process coverage.cobertura.xml into human readable form
  - Uploads all repeortgenerator artifacts into build
  - https://github.com/actions/setup-dotnet
  - https://github.com/Azure/webapps-deploy
  - https://github.com/Azure/actions-workflow-samples/blob/master/AppService/asp.net-core-webapp-on-azure.yml
