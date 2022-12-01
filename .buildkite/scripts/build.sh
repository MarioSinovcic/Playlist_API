#!/usr/bin/env bash

cd "$(dirname $0)"

source "./common.sh"

docker build -f ../../docker/Dockerfile.build -t "$imagetag" ..

docker push "$imagetag"
