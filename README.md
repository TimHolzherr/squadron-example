# Squadron Example

An example on how to use [Squadron](https://github.com/SwissLife-OSS/squadron) to write integration tests for your entity framework core application against a MS Sql Database running inside docker.

## Setup

Make sure you have docker installed ([windows version can be found here](https://docs.docker.com/docker-for-windows/install/)).


### For windows only

Squadron will access the ms sql docker image via ip.
On Windows we need to register a static route for this. 
```
 route /P add 172.17.0.0 MASK 255.255.0.0 10.0.75.2
```

## Run the test 

```
dotnet test
```

# Troubleshooting

* If you get a Timeout exception make sure that docker is actually running
* DockerApiException on windows, restart docker





