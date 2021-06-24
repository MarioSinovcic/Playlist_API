die() { echo "$1:-noooo" >&2; exit 1; }

githash="$(git rev-parse --short HEAD)"

imagetag="274387265859.dkr.ecr.ap-southeast-2.amazonaws.com/mario/playlist-api:${githash}"