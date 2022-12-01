# Playlist-API


### This repo is not functional as data has been obfuscated
 
[![Buildkite status](https://badge.buildkite.com/b7613a89e7b9def6b1c8611c5262a9755dd1a3e7b4905a406f.svg)](https://buildkite.com/companyname/mario-playlist-api)
[![Trufflehog status](https://github.com/companyname-fma/mario-playlist-api/actions/workflows/trufflehog.yml/badge.svg)](https://github.com/companyname-fma/mario-playlist-api/actions/workflows/trufflehog.yml)


# Endpoints
The endpoints have been separated into three controllers: healthcheck, playlists, songs. [Swagger](https://swagger.io/tools/swagger-ui/) has been implemented so when the API and viewed in the browser, a swagger UI doc should be displayed with detailed documentation. 

## /playlists
<details>
  <summary>GET</summary>
  
  ### Get all playlists
  `curl -i https://mario.fma.lab.companynamedev.com/playlists`
  
 * With some
 * Sub bullets
 
</details>
<details>
  <summary>GET/{id}</summary>
  
  ### Get a playlist by id
  ``
 curl -i https://mario.fma.lab.companynamedev.com/playlists
 ``
  
 * With some
 * Sub bullets
</details>
<details>
  <summary>POST/{id}</summary>
  
  ### Updating a playlist by id
  ``curl -i -X POST https://mario.fma.lab.companynamedev.com/playlists/{id}``
  
 * With some
 * Sub bullets
</details>
<details>
  <summary>PUT</summary>
  
  ### Adding a new playlist
  ``curl -i -X PUT https://mario.fma.lab.companynamedev.com/playlists``
  
 * With some
 * Sub bullets
</details>
<details>
  <summary>DELETE/{id}</summary>
  
  ### Deleting a playlist by id
  ``curl -i -X DELETE https://mario.fma.lab.companynamedev.com/playlists/{id}``
 
  * With some
  * Sub bullets
</details>

## /songs
<details>
  <summary>GET</summary>
  
  ### Get songs to browse or get songs by name
    ``curl -i https://mario.fma.lab.companynamedev.com/songs}``
 
   * With some
   * Sub bullets
</details>
<details>
  <summary>GET/{genre}</summary>
  
  ### Get random song by genre
    ``curl -i https://mario.fma.lab.companynamedev.com/songs/{genre}``
 
   * With some
   * Sub bullets
</details>

## /healthcheck
<details>
  <summary>GET</summary>
  
  ### healthcheck
    ``curl -i https://mario.fma.lab.companynamedev.com/healthcheck``
 
   * With some
   * Sub bullets
</details>
