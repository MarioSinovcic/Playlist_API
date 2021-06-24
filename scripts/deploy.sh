#!/usr/bin/env bash

cd "$(dirname $0)"

source "./common.sh"

hash sfm 2>/dev/null || die "missing sfm"

sfm exec -t ../cfn/stack.yml -pi "Image=$imagetag" mario-playlist-api | sfm wait -dots

