#!/usr/bin/env bash

cd "$(dirname $0)"

source "./common.sh"

hash sfm 2>/dev/null || die "missing sfm"

sfm exec -t ../infrastructure/api-ecs-stack.yml -pi "Image=$imagetag" mario-playlist-api | sfm wait -dots

