#!/usr/bin/env bash

buildtag="playlist-api"

docker build -f ./Dockerfile.build -t $buildtag $(dirname $0)/..