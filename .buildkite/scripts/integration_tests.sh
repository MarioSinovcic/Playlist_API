#!/usr/bin/env bash

buildtag="playlist-api-tests"

docker build -f ../../docker/Dockerfile.test -t "$buildtag" $(dirname $0)/..

docker run --rm -it "$buildtag" dotnet test Playlist_API_Tests