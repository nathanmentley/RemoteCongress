#!/usr/bin/env bash

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=../../coverage/coverage.cobertura.xml
cp ./tests/RemoteCongress.Tests/coverage.json coverage.json
reportgenerator -reports:coverage/coverage.cobertura.xml -targetdir:coverage -reportTypes:htmlInline