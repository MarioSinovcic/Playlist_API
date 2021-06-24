#!/usr/bin/env bash

buildtag="playlist-api"

docker build -f $(dirname $0)/../Dockerfile.build -t $buildtag $(dirname $0)/..