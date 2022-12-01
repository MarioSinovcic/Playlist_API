die() { echo "$1" >&2; exit 1; }

githash="$(git rev-parse --short HEAD)"

imagetag="#########/mario/playlist-api:${githash}"