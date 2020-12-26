#!/bin/bash

set -eu

linux="linux-x64"
mac="osx-x64"
win10="win10-x64"

function build_self_contained_dotnet() {
  if [ "$#" -ne 1 ]; then
    echo "Missing target for self-contained build"
    exit 1
  fi
  echo "Building for self-contained executable for $1."
  pushd src/fsharp
  dotnet publish -p:PublishSingleFile=true -p:PublishTrimmed=true -c Release --self-contained -r "$1"
  popd
}

for rid in $linux $mac $win10
do
  build_self_contained_dotnet $rid
done

function build_self_contained_go() {
  pushd src/go/multiplicationPractice
  go build -o bin/multiplicationPractice
  popd
}

build_self_contained_go

