#!/usr/bin/env bash

source "./common.sh"

docker build -f $(dirname $0)/../Dockerfile.build -t "$imagetag" $(dirname $0)/..



docker push "$imagetag"
