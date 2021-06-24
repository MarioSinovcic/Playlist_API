#!/usr/bin/env bash

cd "$(dirname $0)"

source "./common.sh"

docker build -f ../Dockerfile.build -t "$imagetag" ..

docker push "$imagetag"
