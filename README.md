# Itau bank backend challenge

## About

This project contains the source code of the API proposed in the ITAU bank backend challenge, where it is responsible for providing an endpoint for password validations, following the rules below:

* <span style="color:red"> Password is required,
* <span style="color:red"> Password should be at least 9 characters
* <span style="color:red"> Password should be at least 1 digit character
* <span style="color:red"> Password should be at least 1 lowercase letter
* <span style="color:red"> Password should be at least 1 uppercase letter
* <span style="color:red"> Password should be at least 1 special character

## Links
- [Challenge](https://github.com/itidigital/backend-challenge/blob/master/README.md)

## Environment Variables

The following environment variables are needed to run the application:

* `SWAGGER_API_NAME` - Swagger API Name.
* `SWAGGER_YAML_FILE` - Swagger YAML File.
* `SWAGGER_JSON_ROUTE` - Swagger Json Route.
* `HEALTHCHECK_ROUTE` - Healtcheck Route.


## Running the service


### Requirements

- <span style="color:red"> Setup Envirolment Variables via `export` command or via `appsettings.json` file on the FrameworksAndDrivers path of the repo
- <span style="color:red"> DotNet cli (Core SDK)
- <span style="color:red"> DotNet 3.1+
- Node.js v8+ (Optional)
- Npm v6+ or Yarn v1.21+ (Optional)
- Docker (Optional)
- Docker compose (Optional)

### Install dependencies
```
  npm install && npm run restore
```

## How to Run (locally)

### Start Server

- To start this project, open a CMD and run:


```
  npm start
```
or

```
  yarn start
```
or

```
  dotnet run --project ./src/FrameworksAndDrivers
```
or

```
  docker-compose up
```

- Then you can open any browser and hit the url:
  - http://localhost:5000/


### Unit Tests (With coverage analysis and report)
You can check the results on the prompt or open the coverage folder, inside it, open index.html in any browser.

```
  npm test
```
or

```
  yarn test
```

### Unit Tests (Without coverage analysis and reporting)
```
dotnet test backend-challenge.sln
```

## Deployment considerations
To perform the deployment, regardless of the form, whether continuous integration / continuous or manual delivery, the file Dockerfile was added to the project, where it is configured to build and expose the application using port 80, in which case just build the docker image. and create the container using the technology of your choice for orchestration, but I recommend using Kubernets and abstraction tools like terraform and helm charts

### Additional Information
This project already has the integration with the concept of convertional commits, using a library (standard-version) developed in nodejs, where through a few commands (they are registered in the package.json file) it is possible to automate the changes in the CHANGELOG.md file and generate software version tags, respecting the semantic versioning standards